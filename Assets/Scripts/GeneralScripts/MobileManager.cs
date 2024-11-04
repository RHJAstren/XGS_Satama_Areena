using UnityEngine;

public class MobileManager : MonoBehaviour
{
    public GameObject mobileControls;

    /// <summary>
    /// A method to enable or disable mobile controls
    /// </summary>
    /// <param name="isEnabled"> A boolean value to manipulate if a something is enabled or not </param>
    public void EnableMobileControls(bool isEnabled) {
        if (isEnabled)
            mobileControls.SetActive(true);
        else 
            mobileControls.SetActive(false);
    }
}
