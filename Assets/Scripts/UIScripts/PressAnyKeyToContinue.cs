using UnityEngine;
using TMPro;

/// <summary>
/// Simple script to close the info screens entirely.
/// </summary>
public class PressAnyKeyToContinue : MonoBehaviour
{
    [Header ("Pulsating text component")]
    public TextMeshProUGUI text;
    // Speed of the pulse effect
    private float pulseSpeed = 2f;
    private float originalAlpha;


    void Start() {
        if (text != null){
            // Store the original alpha value
            originalAlpha = text.color.a;
        }
    }

    void Update() {
        if (text != null) {
            Color currentColor = text.color;
            // Use Mathf.Abs to ensure the value stays positive, Mathf.Sin to create the pulsating effect
            currentColor.a = originalAlpha * Mathf.Abs(Mathf.Sin(Time.time * pulseSpeed));
            text.color = currentColor;
        }

        if (Input.anyKeyDown) {
            this.gameObject.SetActive(false);
            Debug.Log("Any key pressed");
        }
    }
}
