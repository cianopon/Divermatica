using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] missiles;
    [SerializeField]
    private float delay;
     

	void Start () {
        InvokeRepeating("Spawn", delay, delay);
	}

	void Spawn () {
        int randomMissile = Random.Range(0, 4);
        Instantiate(missiles[randomMissile], new Vector3(Random.Range(-20f, -9f), 6, 0), Quaternion.identity);
	}


}
