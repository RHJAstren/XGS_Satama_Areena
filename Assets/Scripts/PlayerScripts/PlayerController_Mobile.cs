using TMPro;
using UnityEngine;

public class PlayerController_Mobile : PlayerController
{    
    [Header("Mobile Controls")]
    // public Joystick joystick;
    [Header ("testing case")]
    public TextMeshProUGUI text;

    // Update is called once per frame
    protected override void Update() {
        TouchControls();
        HandlePhysicsInGame();
    }

    /// <summary>
    /// Method to control the player with the touch controls
    /// </summary>
    void TouchControls() {
        // float horizontalMovementMobile = joystick.Horizontal;
        // float verticalMovementMobile = joystick.Vertical;
        // text.text = "Horizontal: " + horizontalMovementMobile + " Vertical: " + verticalMovementMobile;

        // Vector3 movePlayerMobile = transform.right * horizontalMovementMobile + transform.forward * verticalMovementMobile;

        // controller.Move(movePlayerMobile * Time.deltaTime * speed);
    }
}
