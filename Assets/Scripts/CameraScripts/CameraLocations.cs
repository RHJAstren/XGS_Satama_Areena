using UnityEngine;
using UnityEngine.UI;

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

    public void changeCameraLocation(int cameraInt) {
        CameraAngles[cameraInt].gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        
        foreach (Transform camera in CameraAngles) {
            if (camera != CameraAngles[cameraInt]) {
                camera.gameObject.SetActive(false);
            }
        }
    }

    public void ReturnCamera() {
        foreach (Transform camera in CameraAngles) {
            camera.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true);
    }
}
