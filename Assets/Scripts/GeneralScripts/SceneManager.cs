using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to contorl the Hall scenes in the project.
/// </summary>
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
    [SerializeField] private GameObject[] Chairs;
    [SerializeField] private GameObject Tables;

    public TextMeshProUGUI fairText;

    private void Start()
    {
        // PC Listeners
        InfoScene.onClick.AddListener(HandleInfoScene);
        ConcertScene.onClick.AddListener(HandleConcertScene);
        SeminarScene.onClick.AddListener(HandleSeminarScene);
        FairScene.onClick.AddListener(HandleFairScene);
    }

    /// <summary>
    /// All the HandleScene scripts can be refactored.
    /// </summary>
    public void HandleInfoScene()
    {
        Debug.Log("Empty Scene Enabled");
        HallInformation.SetActive(true);
        Charts.SetActive(true);
        Concert.SetActive(false);
        Seminar.SetActive(false);
        Fair.SetActive(false);
        foreach (var set in Chairs){
            set.SetActive(false);
        }
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
        Chairs[0].SetActive(false);
        Chairs[1].SetActive(true);
        Tables.SetActive(false);
        fairText.text = "OFF";
    }

    public void HandleSeminarScene()
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
        if (Tables.activeInHierarchy){
            Tables.SetActive(false);
            if (Seminar.activeInHierarchy){
                Chairs[0].SetActive(true);
                Chairs[1].SetActive(false);
            }else if (Concert.activeInHierarchy){
                Chairs[0].SetActive(false);
                Chairs[1].SetActive(true);
            }
            fairText.text = "Chairs";
        }else{
            Tables.SetActive(true);
            Chairs[0].SetActive(false);
            Chairs[1].SetActive(false);
            fairText.text = "Tables";
        }
    }
}
