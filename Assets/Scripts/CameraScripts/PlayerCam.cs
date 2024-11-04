using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCam : MonoBehaviour
{
    [Header ("Sensitivity")]
    public float mouseSensitivity = 100f;
    public float keyRotationSpeed = 1.0f;

    [Header("Camera Orientation")]
    public Transform playerBody;

    [Header ("Rotation variables")]
    public float rotSpeed = 1.0f;
    private int dir = -1;

    // Rotation variables
    private Touch initTouch = new Touch();
    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;
    float xRotation = 0f;

    // Scene managment variables
    Scene scene;
    private int desktopScene = 1;
    //private int mobileScene = 2;
    private float screenDivide = Screen.width / 2;// - (Screen.width * 0.1f);

    private void Start() {
        origRot = playerBody.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    private void Update() {
        if (this.gameObject.activeInHierarchy)
        {
            if (scene.buildIndex == desktopScene)
            {
                KeyboardControls("Rotate X", "Rotate Y", keyRotationSpeed);
                KeyboardControls("Mouse X", "Mouse Y", mouseSensitivity);
            }
            else
                MobileControls(screenDivide);
        }
    }

    /// <summary>
    /// A Method that controls the camera with the keyboard
    /// </summary>
    /// <param name="xAxis"> A string variable that takes a base variable fromt the project settings -> input page. For the x axis. </param>
    /// <param name="yAxis"> A string variable that takes a base variable fromt the project settings -> input page. For the y axis. </param>
    /// <param name="sensitivity"> a float variabel that allows the manipulation of the turn sensitivity in the project </param>
    void KeyboardControls(string xAxis, string yAxis, float sensitivity) {
        float rotationX = Input.GetAxisRaw(xAxis) * sensitivity * Time.deltaTime;
        float rotationY = Input.GetAxisRaw(yAxis) * sensitivity * Time.deltaTime;

        xRotation -= rotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotationX);
    }

    /// <summary>
    /// A method that controls the camera with touch controls
    /// </summary>
    /// <param name="screenWidth"> A base width that divied the screen in half and allows for use of either side for controlling </param>
    void MobileControls(float screenWidth) {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                Touch touch = Input.GetTouch(i);

                if (touch.position.x > screenWidth) {
                    if (touch.phase == TouchPhase.Began){
                        initTouch = touch;
                    }
                    else if (touch.phase == TouchPhase.Moved){

                        float deltaX = initTouch.position.x - touch.position.x;
                        float deltaY = initTouch.position.y - touch.position.y;

                        rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                        rotY += deltaX * Time.deltaTime * rotSpeed * dir;

                        rotX = Mathf.Clamp(rotX, -90f, 90f);

                        playerBody.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                    }
                    else if (touch.phase == TouchPhase.Ended){
                        initTouch = new Touch();
                    }
                }
            }
        }
    }
}
