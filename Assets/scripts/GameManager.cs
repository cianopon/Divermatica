using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool paused;
    private static GameManager instance;


    void Start () {
        

    }
	

	void Update () {

	}

    public void ExitGame()
    {
        Application.Quit(); 
    }

    public void NewGame()
    {
        SceneManager.LoadScene("School");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }




}
