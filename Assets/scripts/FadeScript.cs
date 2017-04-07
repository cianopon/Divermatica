using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {


  

    public void FadeMe(Canvas canvas)
    {
        StartCoroutine(DoFade(canvas));
    }

    IEnumerator DoFade(Canvas canvas)
    {
        CanvasGroup canvasGroup = canvas.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0.5f)
        {
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup.interactable = false;
        yield return null;
    }
}
