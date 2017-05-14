using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour {

    public Image img;

    public static Color AdvColorLerp(float t, params Color[] colors)
    {
        int c = colors.Length - 1;  // number of transitions
        t = Mathf.Clamp01(t) * c;   // expand t from 0-1 to 0-c
        int index = (int) Mathf.Clamp(Mathf.Floor(t), 0, c - 1); // get current index and clamp
        t -= index; // subract the index to get back a value of 0-1
        return Color.Lerp(colors[index], colors[index + 1], t);
    }

    void Update()
    {
        int duration = 3;
        float t = Mathf.Repeat(Time.time, duration) / duration;        
        img.color = AdvColorLerp(t, Color.red, Color.blue, Color.green, Color.red);        
    }

}
