using UnityEngine;
using UnityEngine.UI;

public class HallManager : MonoBehaviour
{
    [Header ("Hall Control Buttons")]
    [SerializeField] private Button extraLargeHall;
    [SerializeField] private Button largeAndExtraSmallHall;
    [SerializeField] private Button multiHallAlt;
    [SerializeField] private Button multiHall;

    [Header ("Curtains (Add XS hall curtain)")]
    [SerializeField] private GameObject curtainMediumHallSide;
    [SerializeField] private GameObject curtainSmallHallSide;
    [SerializeField] private GameObject curtainExtraSmallHall;

    [Header ("GameObjects with Information abou halls")]
    [SerializeField] private GameObject XL_HallInformation;
    [SerializeField] private GameObject L_HallInformation;
    [SerializeField] private GameObject M_HallInformation;
    [SerializeField] private GameObject M_HallInformation_Alternative;
    [SerializeField] private GameObject S_HallInformation;
    [SerializeField] private GameObject S_HallInformation_Alternative;
    [SerializeField] private GameObject XS_HallInformation;

    private bool mediumHallCurtainIsActive = true;
    private bool smallHallCurtainIsActive = true;

    /// <summary>
    /// In a method call, it is possible to create a list of somethings that can be manipulated using the curly braces {} syntax.
    /// The syntax new[] creates a new array of the type specified in the square brackets [].
    /// </summary>
    private void Start()
    {
        // PC Listeners
        extraLargeHall.onClick.AddListener(() => HandleHall(new[] 
        {
            curtainSmallHallSide,
            curtainMediumHallSide, 
            curtainExtraSmallHall,
            XL_HallInformation,
            L_HallInformation,
            M_HallInformation,
            M_HallInformation_Alternative,
            S_HallInformation,
            S_HallInformation_Alternative,
            XS_HallInformation
        }, new[] { false, false, false, true, false, false, false, false, false, false }, "XL Hall"));

        largeAndExtraSmallHall.onClick.AddListener(() => HandleHall(new[] 
        {
            curtainSmallHallSide,
            curtainMediumHallSide,
            curtainExtraSmallHall,
            XL_HallInformation,
            L_HallInformation,
            M_HallInformation,
            M_HallInformation_Alternative,
            S_HallInformation,
            S_HallInformation_Alternative,
            XS_HallInformation
        }, new[] { false, false, true, false, true, false, false, false, false, true }, "XS & L Hall"));

        multiHall.onClick.AddListener(() => HandleHall(new[] 
        {
            curtainSmallHallSide,
            curtainMediumHallSide,
            curtainExtraSmallHall,
            XL_HallInformation,
            L_HallInformation,
            M_HallInformation,
            M_HallInformation_Alternative,
            S_HallInformation,
            S_HallInformation_Alternative,
            XS_HallInformation
        }, new[] { true, true, true, false, false, true, false, true, false, true }, "XS, S & M Hall"));
        
        // Alternate Buttons Listeners
        multiHallAlt.onClick.AddListener(ToggleCurtains);
    }

    /// <summary>
    /// A method to handle the hall curtain activation
    /// </summary>
    /// <param name="objects"> A list of GameObjects that can be manipulated </param>
    /// <param name="states"> A list of boolean states for the GameObjects. 
    /// The key positions refer to each key position in the curtains list </param>
    /// <param name="hallType"> Name of the Hall tat has been activated in the project </param>
    private void HandleHall(GameObject[] objects, bool[] states, string hallType)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(states[i]);
        }
        Debug.Log(hallType + " activated");
    }

    /// <summary>
    /// The toggle controls to the curtains in the scene
    /// In the Debug.Log you can see a small function called a ternary conditional operator.
    /// it works like this: 
    /// boolean (i.e. isActive) ? (ternary) some true value (i.e. isActive) : (conditional) some false value (i.e. !isActive)
    /// for more here is a link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
    /// </summary>
    private void ToggleCurtains()
    {
        curtainExtraSmallHall.SetActive(true);
        XL_HallInformation.SetActive(false);
        L_HallInformation.SetActive(false);
        if (!curtainMediumHallSide.activeInHierarchy)
        {
            mediumHallCurtainIsActive = false;
            smallHallCurtainIsActive = true;
            M_HallInformation.SetActive(mediumHallCurtainIsActive);
            M_HallInformation_Alternative.SetActive(smallHallCurtainIsActive);
            S_HallInformation.SetActive(smallHallCurtainIsActive);
            S_HallInformation_Alternative.SetActive(mediumHallCurtainIsActive);
        }
        else
        {
            mediumHallCurtainIsActive = true;
            smallHallCurtainIsActive = false;
            M_HallInformation.SetActive(mediumHallCurtainIsActive);
            M_HallInformation_Alternative.SetActive(smallHallCurtainIsActive);
            S_HallInformation.SetActive(smallHallCurtainIsActive);
            S_HallInformation_Alternative.SetActive(mediumHallCurtainIsActive);
        }

        curtainMediumHallSide.SetActive(mediumHallCurtainIsActive);
        curtainSmallHallSide.SetActive(smallHallCurtainIsActive);
        Debug.Log($"Medium Hall Curtain is {(mediumHallCurtainIsActive ? "active" : "deactive")}");
        Debug.Log($"Small Hall Curtain is {(smallHallCurtainIsActive ? "active" : "deactive")}");
    }
}
