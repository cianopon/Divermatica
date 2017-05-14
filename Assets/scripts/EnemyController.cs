using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour {

    
    private GameObject currentEnemy;
    [SerializeField]
    private Stat health;
    [SerializeField]
    private GameObject[] enemiesSUMArray,enemiesSUBArray, enemiesMULTarray,enemiesDIVArray;
    private GameObject[][] enemiesArray;
    private QuestionLevel qstLevel;


    public Stat Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
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

    public GameObject CurrentEnemy
    {
        get
        {
            return currentEnemy;
        }

        set
        {
            currentEnemy = value;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        Health.Initialize();
        QstLevel = new QuestionLevel();
        CurrentEnemy = Instantiate(enemiesSUMArray[0]);
        enemiesArray = new GameObject[][]  { enemiesSUMArray, enemiesSUBArray, enemiesMULTarray, enemiesDIVArray };
    }

    public void GotDamage(int damage)
    {
        Health.CurrentVal -= 100;
    }

    public void Destroy ()
    {
        GetComponentInChildren<SlimeSpawner>().Destroy();
        Destroy(CurrentEnemy);
        Destroy(gameObject);
    }


   public  void ChangeEnemy()
    {
  
        QstLevel.IncreaseSubLevel();
        Destroy(currentEnemy);
        CurrentEnemy = Instantiate(enemiesArray[(int)QstLevel.Level][(int)QstLevel.SubLevel]);
        Health.CurrentVal = Health.MaxVal;
               
    }
}
