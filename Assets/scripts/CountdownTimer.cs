using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

    private float timer;
    [SerializeField]
    private float defaultTimeValue;
    private bool isCounting = false, isFinished = false;
    private float fillAmount;
    [SerializeField]
    private Image content;
    [SerializeField]
    private Text valueText;


    public float Timer
    {
        get
        {
            return timer;
        }

        set
        {
            timer = value;
        }
    }

    public bool IsCounting
    {
        get
        {
            return isCounting;
        }

        set
        {
            isCounting = value;
        }
    }

    public bool IsFinished
    {
        get
        {
            return isFinished;
        }

        set
        {
            isFinished = value;
        }
    }

    public float DefaultTimeValue
    {
        get
        {
            return defaultTimeValue;
        }

        set
        {
            defaultTimeValue = value;
        }
    }

    void Start () {
        if (DefaultTimeValue == 0)
            DefaultTimeValue = 5f;
        timer = DefaultTimeValue;

	}
	

	void Update () {

        if (IsCounting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                IsCounting = false;
                IsFinished = true;
            }

            fillAmount = timer;
            HandleBar();
        }
        
	}

    public void ResetTimer()
    {
        timer = DefaultTimeValue;
        IsCounting = false;
        IsFinished = false;
    }

    public void StartCountDown()
    {
        IsCounting = true;
    } 

    public void Restart()
    {
        ResetTimer();
        StartCountDown();
    }

    public void Restart(int newTimeValue)
    {
        DefaultTimeValue = newTimeValue;
        ResetTimer();
        StartCountDown();
    }

    private void HandleBar()
    {
        content.fillAmount = Map(fillAmount,0,DefaultTimeValue,0,1);
        valueText.text = fillAmount.ToString("0.00");

    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {

        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
