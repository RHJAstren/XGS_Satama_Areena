using UnityEngine;

/// <summary>
/// A class that controls the additional cameras in the scene. Inherited from the PlayerCam class.
/// </summary>
public class AdditionalCameraControl : PlayerCam
{

    public PlayerController playerController;

    protected override void Update() {
        if (playerController.isSettingsViewActive == true)
            return;
        else { 
            if (gameObject.activeInHierarchy) {
                Controls("Mouse X", "Mouse Y", mouseSensitivity);
                Controls("Rotate X", "Rotate Y", mouseSensitivity);
            }
        }
    }

    /// <summary>
    /// A Method that controls the additional cameras in the scene with the keyboard
    /// </summary>
    /// <param name="xAxis">The X Axis contorl of the camera. Uses the string for Mouse X and Rotate X for Arrow keys</param>
    /// <param name="yAxis">The Y Axis control of the camera. Uses the string for Mouse Y and Rotate / for Arrow keys</param>
    /// <param name="sensitivity">Sensitivity of the turning radius</param>
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
