using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pausePanel;
    private bool paused;

    void Start()
    {
        pausePanel.SetActive(false);
    }
   

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseGame();                
        }
    }

    public void PauseGame()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }

        else
        {
            pausePanel.SetActive(true);
        }

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
