using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerController_Mobile : PlayerController
{   
    [Header ("Mobile Variables")]
    public Vector2 moveInput;
    private float screenDivide = Screen.width / 2;

    /// <summary>
    /// Method to control the player with the touch controls
    /// </summary>
    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    void JoystickInput(){
        if (Touch.activeTouches.Count > 0){
            foreach (var touch in Touch.activeTouches){
                if (touch.screenPosition.x < screenDivide){
                    Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
                    controller.Move(transform.TransformDirection(move) * speed * Time.deltaTime);
                }
            }
        }
    }

    // Update is called once per frame
    protected override void Update() {
        JoystickInput();
        HandlePhysicsInGame();
    }
}
