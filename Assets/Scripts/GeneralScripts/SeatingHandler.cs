using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to control the rising stands in the main hall S side.
/// </summary>
public class SeatingHandler : MonoBehaviour
{
    public Button[] toggleSwitches;
    public GameObject[] risingStands;
    public GameObject[] checkmarks;

    void Start()
    {
        toggleSwitches[0].onClick.AddListener(() => SetActive(risingStands[0], checkmarks[0]));
        toggleSwitches[1].onClick.AddListener(() => SetActive(risingStands[1], checkmarks[1]));
        toggleSwitches[2].onClick.AddListener(() => SetActive(risingStands[2], checkmarks[2]));
    }

    /// <summary>
    /// Controls which stand is active in the scene.
    /// </summary>
    /// <param name="stand">Which stand from the list of GameObjects.</param>
    /// <param name="mark">The checkmark that is used with the toggle controls.</param>
    public void SetActive(GameObject stand, GameObject mark){
        if (stand.activeInHierarchy){
            stand.SetActive(false);
            mark.SetActive(false);
        }
        else{
            stand.SetActive(true);
            mark.SetActive(true);
        }
    }
}
