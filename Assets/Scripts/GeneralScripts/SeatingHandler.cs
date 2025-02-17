using UnityEngine;
using UnityEngine.UI;

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
