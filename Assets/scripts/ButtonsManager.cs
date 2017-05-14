using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonsManager : MonoBehaviour{

    [SerializeField]
    private Button b1, b2, b3;

    public void CheckKeysPressed()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            b1.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            b2.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            b3.onClick.Invoke();
        }
    }
	

}
