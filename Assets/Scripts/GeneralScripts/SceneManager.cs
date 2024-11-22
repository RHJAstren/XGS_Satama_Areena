using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [Header ("Scene management buttons")]
    [SerializeField] private Button InfoScene;
    [SerializeField] private Button ConcertScene;
    [SerializeField] private Button SeminarScene;
    [SerializeField] private Button ExhibitionScene;

    [Header ("Other variables")]
    [SerializeField] private GameObject HallInformation;
    [SerializeField] private GameObject Charts;
    [SerializeField] private GameObject Concert;
    [SerializeField] private GameObject Ceremony;
    [SerializeField] private GameObject Exhibition;

    private void Start()
    {
        // PC Listeners
        InfoScene.onClick.AddListener(HandleInfoScene);
        ConcertScene.onClick.AddListener(HandleConcertScene);
        SeminarScene.onClick.AddListener(HandleCeremonyScene);
        ExhibitionScene.onClick.AddListener(HandleExhibitionScene);
    }

    public void HandleInfoScene()
    {
        Debug.Log("Empty Scene Enabled");
        HallInformation.SetActive(true);
        Charts.SetActive(true);
        Concert.SetActive(false);
        Ceremony.SetActive(false);
        Exhibition.SetActive(false);
    }

    public void HandleConcertScene()
    {
        Debug.Log("Concert Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(true);
        Ceremony.SetActive(false);
        Exhibition.SetActive(false);
    }

    public void HandleCeremonyScene()
    {
        Debug.Log("Seminar Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(false);
        Ceremony.SetActive(true);
        Exhibition.SetActive(false);
    }

    public void HandleExhibitionScene()
    {
        Debug.Log("Exhibition Scene Enabled");
        HallInformation.SetActive(false);
        Charts.SetActive(false);
        Concert.SetActive(false);
        Ceremony.SetActive(false);
        Exhibition.SetActive(true);
    }
}
