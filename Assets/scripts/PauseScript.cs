using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject pausePanel;

    void Start()
    {
        pausePanel.SetActive(false);
    }
   

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("escape canvas");
           if (pausePanel.activeInHierarchy) 
            pausePanel.SetActive(false);
           else
                pausePanel.SetActive(true);
        }
    }
}
