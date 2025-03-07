using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool activeLocale = false;

    public static LocaleSelector instance;

    /// <summary>
    /// This method is used to change the locale of the game.
    /// </summary>
    /// <param name="localeID">
    /// A parameter that can be determined in Unity Editor and Localization tab to change the language of set text fields.
    /// </param>
    public void ChangeLocale(int localeID)
    {
        if (activeLocale)
            return;
        StartCoroutine(SetLocale(localeID));
    }

    /// <summary>
    /// Coroutine Method to change the locale of the game.
    /// </summary>
    /// <param name="_localeID">
    /// A parameter that can be determined in Unity Editor and Localization tab to change the language of set text fields.
    /// 0 - English
    /// 1 - Finnish
    /// 2 - Russian
    /// 3 - Swedish
    /// </param>
    /// <returns></returns>
    IEnumerator SetLocale(int _localeID)
    {
        activeLocale = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        activeLocale = false;
    }
}
