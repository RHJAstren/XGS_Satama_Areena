using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MobileRotate : MonoBehaviour
{
    public Image img;
    Vector3 originalScale;
    float originalAlpha;

    void Start()
    {
        originalAlpha = img.color.a;
        originalScale = img.transform.localScale;
        StartCoroutine(SplashScreen(2f, 1.05f, .2f));
    }

    IEnumerator SplashScreen(float timer, float growth, float fadeStart){
        Vector3 targetScale = originalScale * growth;

        float elapsed = 0f;

        while (elapsed < timer){
            float t = elapsed / timer;

            img.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

            if (elapsed >= fadeStart){
                float fadeProg = (elapsed - fadeStart) / (timer / fadeStart);

                Color currentColor = img.color;
                currentColor.a = Mathf.Lerp(originalAlpha, 0f, fadeProg);
                img.color = currentColor;
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        img.transform.localScale = targetScale;

        Color finalColor = img.color;
        finalColor.a = 0f;
        img.color = finalColor;

        gameObject.SetActive(false);
    }
}
