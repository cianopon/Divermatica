using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField]
    private Stat health;

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

    private void Awake()
    {
        Health.Initialize();
    }


    void Update () {
		
	}
}
