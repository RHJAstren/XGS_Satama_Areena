using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header ("Control Buttons")]
    public Button MenuBtn;
    public KeyCode menuKey = KeyCode.Space;

    [Header ("Main Menu Genrals")]
    public GameObject Settings;
    public PlayerCam playerCamera;

    [Header ("Control Settings Window")]
    public GameObject RightSettings;
    public GameObject RightSettingsAlternative;
    public TextMeshProUGUI seatingText;
    public GameObject StairSeatings;
    public bool isSettingsViewActive = false;

    [Header("Hall Settings Buttons")]
    public Button[] buttons;
    public GameObject[] hallSetting;
    
    // Private variables
    protected bool isSeatingActive = false;
    protected  Scene scene;
    protected int desktopScene = 1;

    public void Start() { 
        MenuBtn.onClick.AddListener(HandleMainMenuBtn); 
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        for (int i = 0; i < buttons.Length; i++){
            int buttonInt = i;
            buttons[i].onClick.AddListener(() => HandleMainSettingsWindow(buttonInt));
        }
    }

    public virtual void Update() {
        if (Input.GetKeyDown(menuKey)/*Add WASD cloing the settings windw*/)
            HandleMainMenuBtn();
        else if (Input.GetKeyDown(KeyCode.Q))
            RightSettingsAlternative.SetActive(false);

        if (isSeatingActive) 
            seatingText.text = "ON";
        else
            seatingText.text = "OFF"; 
    }

    /// <summary>
    /// A method that handles the main menu button
    /// </summary>
    public virtual void HandleMainMenuBtn() {
        isSettingsViewActive = !isSettingsViewActive;
        if (scene.buildIndex == desktopScene)
            Settings.SetActive(isSettingsViewActive);

        if (isSettingsViewActive)
            EnableMouse();
        else
            DisableMouse();

        if (scene.buildIndex <= desktopScene) {
            bool newState = !playerCamera.enabled;
            playerCamera.enabled = newState;
        }

        RightSettings.SetActive(true);
        RightSettingsAlternative.SetActive(false);
    }

    /// <summary>
    /// A simple method to disable the mouse
    /// </summary>
    public void DisableMouse() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// A simple method to enable the mouse
    /// </summary>
    public void EnableMouse() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HandleSeatings() {
        isSeatingActive = !isSeatingActive;
        StairSeatings.SetActive(isSeatingActive);
    }

    public void HandleMainSettingsWindow(int buttonInt) {
        RightSettingsAlternative.SetActive(true);
        hallSetting[buttonInt].SetActive(true);

        foreach (GameObject setting in hallSetting) {
            if (setting != hallSetting[buttonInt]) {
                setting.SetActive(false);
            }
        }
    }
}
