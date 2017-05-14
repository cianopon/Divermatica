using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
  
    private Question currentQuestion;
    private QuestionLevel qstLevel;

    private Question.Operators currentOperator = Question.Operators.SUM;
    private Text[] arrayTextButtons;
    [SerializeField]
    private Text textQuestion, textButton1, textButton2, textButton3;
    [SerializeField]
    private EnemyController enemyController;
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private ButtonsManager buttonsManager;
    [SerializeField]
    private GameObject HUDCanvas, qstCanvas, gameOverCanvas, GameWonCanvas;
    [SerializeField]
    private Motion[] motions;
    private CountdownTimer countDownTimer;
    private int lastCorrectAwnserIndex = -1;
    private int lastCorrectAnswer = -1;
    private bool isGameOver;

    public QuestionLevel QstLevel
    {
        get
        {
            return qstLevel;
        }

        set
        {
            qstLevel = value;
        }
    }

    private Question CurrentQuestion
    {
        get
        {
            return currentQuestion;
        }

        set
        {
            currentQuestion = value;
        }
    }
 

    void Start()
    {

        Initialize();
        GenerateNewQuestion();

    }

    void Initialize()
    {
        
        QuestionLevel.LevelEnum E_level = QuestionLevel.LevelEnum.SUM;
        QuestionLevel.SubLevelEnum E_SubLevel = QuestionLevel.SubLevelEnum.EASY;
        countDownTimer = GetComponentInParent<CountdownTimer>();
        arrayTextButtons = new Text[] { textButton1,textButton2,textButton3};
        QstLevel = new QuestionLevel(E_level,E_SubLevel);
        enemyController.QstLevel = QstLevel;
    }


    void GenerateNewQuestion()
    {

        switch (currentOperator)
        {
            case Question.Operators.SUM:
                CurrentQuestion = new SumQuestion(QstLevel);
                break;
            case Question.Operators.SUB:
                CurrentQuestion = new SubtractQuestion(QstLevel);
                break;
            case Question.Operators.MULT:
                CurrentQuestion = new MultiplyQuestion(QstLevel);
                break;
            case Question.Operators.DIV:
                CurrentQuestion = new DivideQuestion(QstLevel);
                break;
            default:
                CurrentQuestion = null;
                break;
        }

        CurrentQuestion.Operator1 =  currentOperator;
        CurrentQuestion.LastAnswer = lastCorrectAnswer;
        CurrentQuestion.GenerateQuestion();
        lastCorrectAnswer = CurrentQuestion.CorrectAnswer;
        setQuestionsOnTextButtons();   

        if (CurrentQuestion.QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
        {
            countDownTimer.Restart(10);                        
        }
        else
        {
            countDownTimer.Restart(5);
        }
        


    }


    private void setQuestionsOnTextButtons()
    {
        int randomIndex = UnityEngine.Random.Range(0,3);

        if (lastCorrectAwnserIndex == randomIndex)
        {
            do
            {
                randomIndex = UnityEngine.Random.Range(0, 2);
            } while (randomIndex == lastCorrectAwnserIndex);
            lastCorrectAwnserIndex = randomIndex;
        }
        else
            lastCorrectAwnserIndex = randomIndex;

        int randomAux = -1;
        arrayTextButtons[randomIndex].text = CurrentQuestion.CorrectAnswer.ToString();
  
        for (int i = 0; i<arrayTextButtons.Length; i++)
        {
        
            if (i == randomIndex)
            {
                continue;
            }
            else
            {
                if (randomAux == -1)
                {
                    arrayTextButtons[i].text = CurrentQuestion.RandomAnswer1.ToString();
                    randomAux = i;
                }
                else
                {
                    arrayTextButtons[i].text = CurrentQuestion.RandomAnswer2.ToString();
                }
            }            
        
        }

        textQuestion.text = CurrentQuestion.QuestionToString();
    }

    public void ProcessAnswerMouse(Button button)
    {
        string answerButtonPressed = button.GetComponentInChildren<Text>().text;
        if (CurrentQuestion.CorrectAnswer.ToString().Equals(answerButtonPressed))
        {
            enemyController.GotDamage(25);

            if (enemyController.Health.CurrentVal <= 0)
            {
                if (enemyController.QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
                {
                    if (CurrentQuestion.QstLevel.Level == QuestionLevel.LevelEnum.DIVIDE)
                    {
                        GameWon();
                        return;
                    }
                    else
                    {
                        IncreaseOperatorIndex();
                    }                    
                }
                enemyController.ChangeEnemy();                
            }
        }
        else
        {
            player.GotDamage(10);
        }
        
        GenerateNewQuestion();
        
    }

    void IncreaseOperatorIndex()
    {
        currentOperator++;
    }

 
    void IncreaseLevel()
    {
        QstLevel.IncreaseLevel();
        
    }

    void CheckCounterTimeFinished()
    {
        if(countDownTimer != null)
        {
            if (countDownTimer.IsFinished)
            {
                player.GotDamage(10);
                GenerateNewQuestion();
            }
        }
        
    }

    public void CheckPlayersLife()
    {
        if (player.Health.CurrentVal <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        HUDCanvas.SetActive(false);
        qstCanvas.SetActive(false);
        DestroyGameElements();
        gameOverCanvas.SetActive(true);

    }

    private void GameWon()
    {
        isGameOver = true;
        HUDCanvas.SetActive(false);
        qstCanvas.SetActive(false);
        DestroyGameElements();
        GameWonCanvas.SetActive(true);
    }

    private void DestroyGameElements()
    {
        Destroy(player.gameObject);
        enemyController.Destroy();
        Destroy(enemyController.gameObject);
    }

    void Update()
    {
        if (!isGameOver)
        {
            CheckCounterTimeFinished();
            buttonsManager.CheckKeysPressed();
            CheckPlayersLife();
        }
        
    }


}
