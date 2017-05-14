using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLevel  {

    public enum LevelEnum { SUM, SUBTRACT, MULTIPLY, DIVIDE }
    public enum SubLevelEnum { EASY, MEDIUM, HARD, BOSS }

    private LevelEnum level;
    private SubLevelEnum subLevel;


    public LevelEnum Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public SubLevelEnum SubLevel
    {
        get
        {
            return subLevel;
        }

        set
        {
            subLevel = value;
        }
    }



    public QuestionLevel(QuestionLevel.LevelEnum level, QuestionLevel.SubLevelEnum subLevel)
    {
        Level = level;
        SubLevel = subLevel;
    }

    public QuestionLevel()
    {
        Level = LevelEnum.SUM;
        SubLevel = SubLevelEnum.EASY;
    }

    public void IncreaseLevel()
    {
        if (Level != LevelEnum.DIVIDE)
        {
            Level++;
            SubLevel = SubLevelEnum.EASY;
        }

    }

    public void IncreaseSubLevel()
    {

        if (SubLevel != SubLevelEnum.BOSS)
        {
            SubLevel++;
        }
        else
        {            
            IncreaseLevel();
            
        }

    }

}
