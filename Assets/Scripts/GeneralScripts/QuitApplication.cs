using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    /// <summary>
    /// Mathod to handle Quit action in a button UI element.
    /// </summary>
    public void HandleButtonPress()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
