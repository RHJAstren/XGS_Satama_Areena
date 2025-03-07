using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoTableManager : MonoBehaviour
{
    [Header("Close Button")]
    public PlayerCam playerCamera;
    [SerializeField] private UIController uiController;
    public PlayerController playerController;
    public GameObject Menu_UI;
    public GameObject MobileJoystick;
    [Header("Text Fields")]
    public GameObject[] textTitles;
    public GameObject[] textFields;
    [Header("Buttons")]
    public GameObject closeButton;
    public GameObject nextPageBtn;
    public GameObject prevPageBtn;

    protected int textPage = 0;
    protected int mobileScene = 2;
    protected Scene scene;

    public void Start() { scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); }

    /// <summary>
    /// Method that closes the instructions tab and allows 
    /// the player to move in the scene
    /// </summary>
    public virtual void onCloseButton()
    {
        uiController.DisableMouse();
        playerCamera.enabled = true;
        playerController.enabled = true;
        Menu_UI.SetActive(true);
        closeButton.SetActive(false);
        nextPageBtn.SetActive(false);
        prevPageBtn.SetActive(false);
        if (scene.buildIndex == mobileScene)
        {
            MobileJoystick.SetActive(true);
        }
    }

    /// <summary>
    /// Method to change information page of the info table to the next
    /// </summary>
    public void onNextPageButton()
    {
        textPage++;
        UpdatePage();
    }

    /// <summary>
    /// Method to change information page of the info table to the previous
    /// </summary>
    public void onPrevPageButton()
    {
        textPage--;
        UpdatePage();
    }

    /// <summary>
    /// Updates the page based on the current textPage and titleIndex.
    /// </summary>
    private void UpdatePage()
    {
        // Ensure the textPage index is within the valid range
        textPage = Mathf.Clamp(textPage, 0, textFields.Length - 1);

        // Update text fields visibility
        for (int i = 0; i < textFields.Length; i++)
        {
            textFields[i].SetActive(i == textPage);
        }

        if (textPage == textFields.Length - 1)
        {
            textTitles[0].SetActive(false);
            textTitles[1].SetActive(true);
        }
        else
        {
            textTitles[0].SetActive(true);
            textTitles[1].SetActive(false);
        }

        // Update buttons visibility
        prevPageBtn.SetActive(textPage > 0);
        nextPageBtn.SetActive(textPage < textFields.Length - 1);
    }
}
