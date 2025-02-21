using UnityEngine;

public class AdditionalCameraControl : MonoBehaviour
{
    private float sensitivity = 100f;

    public PlayerController playerController;

    private void Update() {
        if (playerController.isSettingsViewActive == true)
            return;
        else { 
            if (gameObject.activeInHierarchy) {
                Controls("Mouse X", "Mouse Y", sensitivity);
                Controls("Rotate X", "Rotate Y", sensitivity);
            }
        }
    }

    void Controls(string xAxis, string yAxis, float sensitivity) {
        Vector3 currentRotation = transform.localEulerAngles;

        // Convert current X rotation to a range of -180 to 180 for proper clamping
        float currentRotationX = currentRotation.x > 180 ? currentRotation.x - 360 : currentRotation.x;

        float rotationX = Input.GetAxisRaw(xAxis) * sensitivity * Time.deltaTime;
        float rotationY = Input.GetAxisRaw(yAxis) * sensitivity * Time.deltaTime;

        currentRotationX = Mathf.Clamp(currentRotationX - rotationY, 0f, 75f);

        transform.Rotate(Vector3.up * rotationX);
        transform.localEulerAngles = new Vector3(currentRotationX, transform.localEulerAngles.y, 0f);
    }
}
