using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool paused;
    private static GameManager instance;


    void Start () {
        

    }
	

	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            if (paused)
            {
                Time.timeScale = 1;
                paused = false;
               
            } 
            else
            {
             
                Time.timeScale = 0;
                paused = true;
            }
            
        }
	}

  
}
