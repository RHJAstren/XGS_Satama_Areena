using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to control the starting screen with the locale and device selectors.
/// </summary>
public class StartController : MonoBehaviour
{
    [Header ("UI Elements")]
    public GameObject languageSelection;
    public GameObject platformSelection;
    public Slider slider;
    public TextMeshProUGUI loadingNumber;

    public void HandleLanguageButtonPress()
    {
        languageSelection.SetActive(false);
        platformSelection.SetActive(true);
    }

    public void HandlePlatformButtonPress (int scene)
    {
        StartCoroutine(LoadAsync(scene));
    }

    /// <summary>
    /// Loads the scene.
    /// </summary>
    /// <param name="scene">The build index of the scene that will be opened
    /// 0 - Start Scene
    /// 1 - Desktop Scene
    /// 2 - Mobile Scene
    /// </param>
    /// <returns></returns>
    IEnumerator LoadAsync(int scene)
    {
        loadingNumber.text = "0%";
        yield return new WaitForSeconds(0.1f);
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingNumber.text = (slider.value * 100f).ToString("0") + "%";

            slider.value = progress;

            yield return null;
        }
    }
}
