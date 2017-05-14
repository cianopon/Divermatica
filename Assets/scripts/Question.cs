

using UnityEngine;

internal class Question
{
    public enum Operators { SUM, SUB, MULT, DIV };
    private int correctAnswer, lastAnswer = 0, randomAnswer1 = 0, randomAnswer2 = 0;
    private int qstElement1, qstElement2, qstElement3;
    private string[] operadoresArray = { "+", "-", "*", "/" };
    private QuestionLevel qstLevel;
    private Operators operator1, operator2;
    
    
    

    public Question(QuestionLevel level)
    {
        QstLevel = level;
    }


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

    public int CorrectAnswer
    {
        get
        {
            return correctAnswer;
        }

        set
        {
            correctAnswer = value;
        }
    }

    public int RandomAnswer1
    {
        get
        {
            return randomAnswer1;
        }

        set
        {
            randomAnswer1 = value;
        }
    }

    public int RandomAnswer2
    {
        get
        {
            return randomAnswer2;
        }

        set
        {
            randomAnswer2 = value;
        }
    }

    public int QstElement1
    {
        get
        {
            return qstElement1;
        }

        set
        {
            qstElement1 = value;
        }
    }

    public int QstElement2
    {
        get
        {
            return qstElement2;
        }

        set
        {
            qstElement2 = value;
        }
    }

    public int QstElement3
    {
        get
        {
            return qstElement3;
        }

        set
        {
            qstElement3 = value;
        }
    }

    public string[] OperadoresArray
    {
        get
        {
            return operadoresArray;
        }

        set
        {
            operadoresArray = value;
        }
    }

    internal Operators Operator1
    {
        get
        {
            return operator1;
        }

        set
        {
            operator1 = value;
        }
    }

    internal Operators Operator2
    {
        get
        {
            return operator2;
        }

        set
        {
            operator2 = value;
        }
    }

    public int LastAnswer
    {
        get
        {
            return lastAnswer;
        }

        set
        {
            lastAnswer = value;
        }
    }

    public virtual void GenerateQuestion()
    {

    }


    public virtual void GenerateRandomQuestions()
    {

    }

    public virtual string QuestionToString()
    {
        if (QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
        {
            return QstElement1 + " " + OperadoresArray[(int)Operator1] + " " + QstElement2 + " " + OperadoresArray[(int)Operator2] + " " + QstElement3 + " = ";
        }
        else
        {
            return QstElement1 + " " + OperadoresArray[(int)Operator1] + " " + QstElement2 + " = ";
        }
    }

    public void SetLevel(QuestionLevel.LevelEnum level)
    {
        QstLevel.Level = level;
    }


}

class SumQuestion : Question

{
    public SumQuestion(QuestionLevel level) : base (level)
    {
        
    }

    public override void GenerateQuestion()
    {

        GenerateQstElements();
        GenerateRandomQuestions();
    }

    public void GenerateQstElements()
    {
        switch (QstLevel.SubLevel) // SumQuestion
        {
            case QuestionLevel.SubLevelEnum.EASY:
                QstElement1 = UnityEngine.Random.Range(1, 10);
                QstElement2 = UnityEngine.Random.Range(1, 10);
                break;
            case QuestionLevel.SubLevelEnum.MEDIUM:
                QstElement1 = UnityEngine.Random.Range(3, 12);
                QstElement2 = UnityEngine.Random.Range(3, 12);
                break;
            case QuestionLevel.SubLevelEnum.HARD:
                QstElement1 = UnityEngine.Random.Range(5, 15);
                QstElement2 = UnityEngine.Random.Range(5, 15);
                break;
            case QuestionLevel.SubLevelEnum.BOSS:
                QstElement1 = UnityEngine.Random.Range(5, 15);
                QstElement2 = UnityEngine.Random.Range(5, 15);
                QstElement3 = UnityEngine.Random.Range(5, 15);
                break;
        }

        if (QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
        {
            CorrectAnswer = QstElement1 + QstElement2 + QstElement3;
            Operator2 = Operators.SUM;
        }
        else
        {
            CorrectAnswer = QstElement1 + QstElement2;
        }

        while (LastAnswer == CorrectAnswer)
        {
            GenerateQstElements();
        }
    }

    public override void GenerateRandomQuestions() // SumQuestion
    {
        RandomAnswer1 = CorrectAnswer + UnityEngine.Random.Range(1, 5);

        do
            {
                    if (CorrectAnswer < 5)
                    {
                        RandomAnswer2 = RandomAnswer1 + UnityEngine.Random.Range(1, 5);
                    }
                    else
                    {
                        RandomAnswer2 = CorrectAnswer - UnityEngine.Random.Range(1, 5);
                    }

                } while (!(RandomAnswer2 != CorrectAnswer && RandomAnswer2 != RandomAnswer1));
            }
    }

class SubtractQuestion : Question
{

    public SubtractQuestion(QuestionLevel level) : base(level)
    {

    }
    public override void GenerateQuestion()
    {
        GenerateQstElements();        
        GenerateRandomQuestions();
    }

    void GenerateQstElements() // SUBTRACT QUESTIONS
    {
        switch (QstLevel.SubLevel)
        {
            case QuestionLevel.SubLevelEnum.EASY:
                QstElement1 = UnityEngine.Random.Range(3, 10);
                QstElement2 = UnityEngine.Random.Range(1, 10);
                break;
            case QuestionLevel.SubLevelEnum.MEDIUM:
                QstElement1 = UnityEngine.Random.Range(3, 12);
                QstElement2 = UnityEngine.Random.Range(2, 10);
                break;
            case QuestionLevel.SubLevelEnum.HARD:
                QstElement1 = UnityEngine.Random.Range(5, 15);
                QstElement2 = UnityEngine.Random.Range(5, 15);
                break;
            case QuestionLevel.SubLevelEnum.BOSS:
                QstElement1 = UnityEngine.Random.Range(5, 15);
                QstElement2 = UnityEngine.Random.Range(1, 10);
                QstElement3 = UnityEngine.Random.Range(1, 5);
                break;
        }

        if (QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
        {
            CorrectAnswer = QstElement1 - QstElement2 - QstElement3;
            Operator2 = Operators.SUB;
        }
        else
        {
            CorrectAnswer = QstElement1 - QstElement2;
        }

        ValidateValuesOrder();
        while (LastAnswer == CorrectAnswer)
        {
            GenerateQstElements();
        }
    }

    public void ValidateValuesOrder() // SUBTRACT QUESTIONS
    {
        int aux;             
          
                        
            if (QstElement1 < QstElement2)
            {
                aux = QstElement1;
                QstElement1 = QstElement2;
                QstElement2 = aux;
                CorrectAnswer = QstElement1 - QstElement2;
            }
            else
            {
                if (QstElement1 == QstElement2)
                {
                    do
                    {
                        QstElement2 = QstElement1 - Random.Range(1, 5);
                        CorrectAnswer = QstElement1 - QstElement2;
                    } while (CorrectAnswer <= 0);
                }
            }
    }

    public override void GenerateRandomQuestions() // SUBTRACT QUESTIONS
    {
        RandomAnswer1 = CorrectAnswer + UnityEngine.Random.Range(1, 5);
        do
        {
            if (CorrectAnswer < 5)
            {
                
                RandomAnswer2 = RandomAnswer1 + UnityEngine.Random.Range(1, 5);
            }
            else
            {
                do
                {
                    RandomAnswer2 = CorrectAnswer - UnityEngine.Random.Range(1, 5);
                }
                while (RandomAnswer2 <= 0);
               
            }

        } while (!(RandomAnswer2 != CorrectAnswer && RandomAnswer2 != RandomAnswer1));
    }
}

class MultiplyQuestion : Question
{
    public MultiplyQuestion(QuestionLevel level) : base(level)
    {

    }
    public override void GenerateQuestion()
    {
        GenerateQstElements();
        GenerateRandomQuestions();
    }

    public void GenerateQstElements() // MULTIPLY QUESTIONS
    {
        switch (QstLevel.SubLevel)
        {
            case QuestionLevel.SubLevelEnum.EASY:
                QstElement1 = UnityEngine.Random.Range(2, 6);
                QstElement2 = UnityEngine.Random.Range(2, 6);
                break;
            case QuestionLevel.SubLevelEnum.MEDIUM:
                QstElement1 = UnityEngine.Random.Range(2, 10);
                QstElement2 = UnityEngine.Random.Range(2, 10);
                break;
            case QuestionLevel.SubLevelEnum.HARD:
                QstElement1 = UnityEngine.Random.Range(2, 12);
                QstElement2 = UnityEngine.Random.Range(2, 12);
                break;
            case QuestionLevel.SubLevelEnum.BOSS:
                QstElement1 = UnityEngine.Random.Range(2, 8);
                QstElement2 = UnityEngine.Random.Range(2, 6);
                QstElement3 = UnityEngine.Random.Range(2, 6);
                break;
        }

        if (QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
        {
            CorrectAnswer = QstElement1 * QstElement2 * QstElement3;
            Operator2 = Operators.MULT;
        }
        else
        {
            CorrectAnswer = QstElement1 * QstElement2;
        }

        while (LastAnswer == CorrectAnswer)
        {
            GenerateQstElements();
        }
    }

    public override void GenerateRandomQuestions() // MULTIPLY QUESTIONS
    {
        RandomAnswer1 = CorrectAnswer + UnityEngine.Random.Range(1, 5);

        do
        {
            if (CorrectAnswer < 5)
            {
                RandomAnswer2 = RandomAnswer1 + UnityEngine.Random.Range(1, 5);
            }
            else
            {
                RandomAnswer2 = CorrectAnswer - UnityEngine.Random.Range(1, 5);
            }

        } while (!(RandomAnswer2 != CorrectAnswer && RandomAnswer2 != RandomAnswer1));
    }
}




    class DivideQuestion : Question
    {
        public DivideQuestion(QuestionLevel level) : base(level)
        {

        }

        public override void GenerateQuestion()
        {

        do
        {
            GenerateQstElements();
        } while (LastAnswer == CorrectAnswer);
        GenerateRandomQuestions();
    }

        public void GenerateQstElements() // DIVIDE QUESTIONS
        {
            switch (QstLevel.SubLevel)
            {
                case QuestionLevel.SubLevelEnum.EASY:
                    QstElement1 = UnityEngine.Random.Range(4, 10);
                    QstElement2 = UnityEngine.Random.Range(2, 5);
                    break;
                case QuestionLevel.SubLevelEnum.MEDIUM:
                    QstElement1 = UnityEngine.Random.Range(4, 12);
                    QstElement2 = UnityEngine.Random.Range(2, 6);
                    break;
                case QuestionLevel.SubLevelEnum.HARD:
                    QstElement1 = UnityEngine.Random.Range(4, 16);
                    QstElement2 = UnityEngine.Random.Range(2, 18);
                    break;
                case QuestionLevel.SubLevelEnum.BOSS:
                    QstElement1 = UnityEngine.Random.Range(4, 20);
                    QstElement2 = UnityEngine.Random.Range(2, 10);
                    QstElement3 = UnityEngine.Random.Range(5, 10);
                    break;
            }

        ValidateValuesOrder();
            
        }



    public void ValidateValuesOrder() // DIVIDE QUESTIONS
    {
        int aux;

        if (QstElement1 < QstElement2)
        {
            aux = QstElement1;
            QstElement1 = QstElement2;
            QstElement2 = aux;
        }

        if ((QstElement1 % QstElement2 == 0) && (QstElement1 / QstElement2 != 0))
        {
            if (QstLevel.SubLevel == QuestionLevel.SubLevelEnum.BOSS)
            {
                CorrectAnswer = QstElement1 / QstElement2 + QstElement3;
            }
            else
            {
                CorrectAnswer = QstElement1 / QstElement2;
            }
            
        }
        else
        {
            GenerateQstElements();
        }

                      
        
    }

    public override void GenerateRandomQuestions() // DIVIDE QUESTIONS
    {
        RandomAnswer1 = CorrectAnswer + UnityEngine.Random.Range(1, 5);

        do
        {
            if (CorrectAnswer < 5)
            {
                RandomAnswer2 = RandomAnswer1 + UnityEngine.Random.Range(1, 5);
            }
            else
            {
                RandomAnswer2 = CorrectAnswer - UnityEngine.Random.Range(1, 5);
            }

        } while (!(RandomAnswer2 != CorrectAnswer && RandomAnswer2 != RandomAnswer1));
    }

}
