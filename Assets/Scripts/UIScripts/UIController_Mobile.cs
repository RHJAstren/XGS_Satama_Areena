using UnityEngine;
using UnityEngine.UI;

public class UIController_Mobile : UIController
{
    public Button[] moreOptions;
    public GameObject[] settingsPage;

    protected override void Start()
    {
        base.Start();
        moreOptions[0].onClick.AddListener(() => SetPages(new[]{settingsPage[0], settingsPage[1]}));
        moreOptions[1].onClick.AddListener(() => SetPages(new[]{settingsPage[1], settingsPage[0]}));
        EnableMouse();
    }

    public override void Update()
    {
        if (Input.GetKeyDown(menuKey))
            HandleMainMenuBtn();

        if (Input.GetKeyDown(KeyCode.E))
            EnableMouse();
        if (Input.GetKeyDown(KeyCode.R))
            DisableMouse();
    }

    /// <summary>
    /// A method that handles the main menu button
    /// </summary>
    public override void HandleMainMenuBtn()
    {
        isSettingsViewActive = !isSettingsViewActive;
        if (scene.buildIndex != desktopScene)
            Settings.SetActive(isSettingsViewActive);

        if (!isSettingsViewActive)
        {
            if (scene.buildIndex <= desktopScene)
            {
                bool newState = !playerCamera.enabled;
                playerCamera.enabled = newState;
            }

            RightSettings.SetActive(true);
            RightSettingsAlternative.SetActive(false);
        }
    }

    public void SetPages(GameObject[] Page){
        Page[0].SetActive(true);
        Page[1].SetActive(false);
    }
}
