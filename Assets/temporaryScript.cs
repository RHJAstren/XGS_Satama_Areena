using UnityEngine;
using UnityEngine.UI;

public class temporaryScript : MonoBehaviour
{
    public Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton.interactable = false;
    }
}
