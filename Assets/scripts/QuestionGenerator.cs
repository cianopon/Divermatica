using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{

    enum Operators { ADD, SUB, MULT, DIV };

    [SerializeField]
    private Text textQuestion,textButton1,textButton2,textButton3;

    private int CorrectAnswer = 0, randomAnswer1 = 0, randomAnswer2 = 0;
    private int qstElement1, qstElement2, qstElement3;
    private string[] operadoresArray = { "+", "-", "*", "/" };
    [SerializeField]
    private EnemyScript enemyScript;
    [SerializeField]
    private CountdownTimer countDownTimer;

  

    void GenerateQuestion()
    {
        Operators opr = (Operators)Random.Range(0, 2);
        qstElement1 = Random.Range(1, 20);
        qstElement2 = Random.Range(1, 20);
        switch ((int)opr)
        {
            case 0: CorrectAnswer = qstElement1 + qstElement2; break;
            case 1: CorrectAnswer = qstElement1 - qstElement2; break;
            case 2: CorrectAnswer = qstElement1 * qstElement2; break;
            case 3: CorrectAnswer = qstElement1 / qstElement2; break;
        }

        do
        {
            randomAnswer1 = RandomQstGen(opr);
        } while (CorrectAnswer == randomAnswer1);

        do
        {
            randomAnswer2 = RandomQstGen(opr);
        } while (!(randomAnswer2 != CorrectAnswer && randomAnswer2 != randomAnswer1));

        textButton1.text = CorrectAnswer.ToString();
        textButton2.text = randomAnswer1.ToString();
        textButton3.text = randomAnswer2.ToString();
        textQuestion.text = qstElement1 + " " + operadoresArray[(int)opr] + " " + qstElement2 + " = ";
        countDownTimer.startCountDown();
       
    }

    private int RandomQstGen(Operators opr)
    {
        int randomQst = 0;
        switch ((int)opr)
        {
            case 0: randomQst = Random.Range(1, 20) + Random.Range(1, 20); break;
            case 1: randomQst = Random.Range(1, 20) - Random.Range(1, 20); break;
            case 2: randomQst = Random.Range(1, 20) * Random.Range(1, 20); break;
            case 3: randomQst = Random.Range(1, 20) / Random.Range(1, 20); break;
        }
        return randomQst;
    }

   public void ProcessAnswer(Button button)
    {
        string answerButtonPressed = button.GetComponentInChildren<Text>().text;
        if (CorrectAnswer.ToString().Equals(answerButtonPressed))
        {
            enemyScript.Health.CurrentVal -= 25;
        }
        GenerateQuestion();
    }

 

    void Start()
    {
        GenerateQuestion();
    }

    void Update()
    {
        
    }


}
