using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header ("Sensitivity")]
    public float mouseSensitivity = 100f;
    public float keyRotationSpeed = 1.0f;

    [Header("Camera Orientation")]
    public Transform playerBody;

    [Header ("Rotation variables")]
    public float rotSpeed = 1.0f;

    // Rotation variables
    float xRotation = 0f;

    protected virtual void Update() {
        KeyboardControls("Rotate X", "Rotate Y", keyRotationSpeed);
        KeyboardControls("Mouse X", "Mouse Y", mouseSensitivity);
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
}
