using UnityEngine;

/// <summary>
/// Main script for the player controller.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header ("Character Controller")]
    public CharacterController controller;
    public float speed = 12f;
    

    [Header ("Check Ground")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public bool isSettingsViewActive = false;

    void Start()
    {
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    protected virtual void Update(){
        Controls();
        HandlePhysicsInGame();
    }

    /// <summary>
    /// Method to control the player with the keyboard
    /// </summary>
    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isSettingsViewActive = !isSettingsViewActive;

        if (isSettingsViewActive)
            return;
        else {
            float horizontalMovementKeyboard = Input.GetAxis("Horizontal");
            float verticalMovementKeyboard = Input.GetAxis("Vertical");

            Vector3 movePlayerKeyboard = transform.right * horizontalMovementKeyboard + transform.forward * verticalMovementKeyboard;
            
            if (Input.GetKey(KeyCode.LeftShift))
                controller.Move(movePlayerKeyboard * Time.deltaTime * speed * 2);
            else
                controller.Move(movePlayerKeyboard * Time.deltaTime * speed);
        }
    }

    /// <summary>
    /// Method to handle the basic physics of the player
    /// </summary>
    public void HandlePhysicsInGame() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
