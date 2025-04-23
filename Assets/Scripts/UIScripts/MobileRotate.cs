using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for the opening images for the user to rotate the phone vertically.
/// </summary>
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

    /// <summary>
    /// A Courutine to increase the size of the image in the info screen.
    /// </summary>
    /// <param name="timer">A float based timer to increase the size of the image and deactivate the panel.</param>
    /// <param name="growth">The amount the image grows over time.</param>
    /// <param name="fadeStart">The moment the image starts to fade away.</param>
    /// <returns></returns>
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
