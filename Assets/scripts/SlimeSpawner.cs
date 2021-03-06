﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject Slime;
    [SerializeField]
    private float delay;
    private float [] spawnPoints = {-1.50f,-3,-4.20f};
    private GameObject currentSlime;

    public void Destroy ()
    {
        Destroy(currentSlime);
        Destroy(gameObject);
    }

    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn()
    {
        currentSlime = Instantiate(Slime, new Vector3(-4, spawnPoints[Random.Range(0, 3)], 0), Quaternion.identity);
    }

}
