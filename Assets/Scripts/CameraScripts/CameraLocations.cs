using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script that is used to change the camera angle of the player.
/// </summary>
public class CameraLocations : MonoBehaviour
{
    [Header("Camera locations")]
    [SerializeField] private Transform[] CameraAngles;

    [Header("UI Buttons")]
    [SerializeField] private Button[] CameraBtns;

    [Header("Main Camera")]
    [SerializeField] private Camera mainCamera;

    private void Start() {
        for (int i = 0; i < CameraBtns.Length; i++) {
            int cameraInt = i;
            CameraBtns[i].onClick.AddListener(() => changeCameraLocation(cameraInt));
        }
    }

    /// <summary>
    /// Changes which camera in the scene is active.
    /// </summary>
    /// <param name="cameraInt">Taken from a list of cameras. Controlled in the Unity Editor</param>
    public void changeCameraLocation(int cameraInt) {
        CameraAngles[cameraInt].gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        
        foreach (Transform camera in CameraAngles) {
            if (camera != CameraAngles[cameraInt]) {
                camera.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Returns the camera to the player camera in the scene.
    /// </summary>
    public void ReturnCamera() {
        foreach (Transform camera in CameraAngles) {
            camera.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true);
    }
}
