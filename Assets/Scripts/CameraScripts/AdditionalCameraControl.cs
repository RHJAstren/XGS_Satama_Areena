using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditionalCameraControl : MonoBehaviour
{
    private float sensitivity = 100f;

    Scene scene;
    private int desktopScene = 1;
    public PlayerController playerController;

    private void Start() { scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); }

    private void Update() {
        if (playerController.isSettingsViewActive == true)
            return;
        else { 
            if (this.gameObject.activeInHierarchy) {
                if (scene.buildIndex == desktopScene) {
                    KeyboardControls("Mouse X", "Mouse Y", sensitivity);
                    KeyboardControls("Rotate X", "Rotate Y", sensitivity);
                }
                else
                    Debug.Log("Mobile controls not implemented yet");
            }
        }
    }

    void KeyboardControls(string xAxis, string yAxis, float sensitivity) {
        Vector3 currentRotation = transform.localEulerAngles;

        // Convert current X rotation to a range of -180 to 180 for proper clamping
        float currentRotationX = currentRotation.x > 180 ? currentRotation.x - 360 : currentRotation.x;

        float rotationX = Input.GetAxisRaw(xAxis) * sensitivity * Time.deltaTime;
        float rotationY = Input.GetAxisRaw(yAxis) * sensitivity * Time.deltaTime;

        currentRotationX = Mathf.Clamp(currentRotationX - rotationY, 0f, 90f);

        transform.Rotate(Vector3.up * rotationX);
        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, 0f);
    }
}
