using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [Header ("Scene management buttons")]
    [SerializeField] private Button InfoScene;
    [SerializeField] private Button ConcertScene;
    [SerializeField] private Button SeminarScene;
    [SerializeField] private Button FairScene;

    [Header ("Scenes")]
    [SerializeField] private GameObject HallInformation;
    [SerializeField] private GameObject Charts;
    [SerializeField] private GameObject Concert;
    [SerializeField] private GameObject Seminar;
    [SerializeField] private GameObject Fair;

    [Header ("Additional")]
    [SerializeField] private GameObject Chairs;
    [SerializeField] private GameObject Tables;

    public TextMeshProUGUI fairText;

    private void Start()
    {
        // PC Listeners
        InfoScene.onClick.AddListener(HandleInfoScene);
        ConcertScene.onClick.AddListener(HandleConcertScene);
        SeminarScene.onClick.AddListener(HandleCeremonyScene);
        FairScene.onClick.AddListener(HandleFairScene);
    }

    public void HandleInfoScene()
    {
        Debug.Log("Empty Scene Enabled");
        HallInformation.SetActive(true);
        Charts.SetActive(true);
        Concert.SetActive(false);
        Seminar.SetActive(false);
        Fair.SetActive(false);
        Chairs.SetActive(true);
        Tables.SetActive(false);
        fairText.text = "OFF";
    }

    public void HandleConcertScene()
    {
        Debug.Log("Concert Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(true);
        Seminar.SetActive(false);
        Fair.SetActive(false);
        Chairs.SetActive(true);
        Tables.SetActive(false);
        fairText.text = "OFF";
    }

    public void HandleCeremonyScene()
    {
        Debug.Log("Seminar Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(false);
        Seminar.SetActive(true);
    }

    public void HandleFairScene()
    {
        Debug.Log("Exhibition Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(false);
        Fair.SetActive(true);
        if (Chairs.activeInHierarchy){
            Tables.SetActive(true);
            Chairs.SetActive(false);
            fairText.text = "Tables";
        }else{
            Tables.SetActive(false);
            Chairs.SetActive(true);
            fairText.text = "Chairs";
        }
    }
}
