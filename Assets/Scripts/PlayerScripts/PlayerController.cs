using System;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Character Controller")]
    public CharacterController controller;
    public float speed = 12f;
    public Joystick joystick;
    public GameObject mobileControls;

    [Header ("Check Ground")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header ("testing case")]
    public TextMeshProUGUI text;

    Vector3 velocity;
    bool isGrounded;
    public bool isSettingsViewActive = false;

    private void Update(){
        if (mobileControls.activeInHierarchy == true)
            TouchControls();
        else
            KeyboardControls();

        HandlePhysicsInGame();
    }

    /// <summary>
    /// Method to control the player with the touch controls
    /// </summary>
    void TouchControls() {
        float horizontalMovementMobile = joystick.Horizontal;
        float verticalMovementMobile = joystick.Vertical;
        text.text = "Horizontal: " + horizontalMovementMobile + " Vertical: " + verticalMovementMobile;

        Vector3 movePlayerMobile = transform.right * horizontalMovementMobile + transform.forward * verticalMovementMobile;

        controller.Move(movePlayerMobile * Time.deltaTime * speed);
    }

    /// <summary>
    /// Method to control the player with the keyboard
    /// </summary>
    void KeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isSettingsViewActive = !isSettingsViewActive;

        if (isSettingsViewActive)
            return;
        else {
            float horizontalMovementKeyboard = Input.GetAxis("Horizontal");
            float verticalMovementKeyboard = Input.GetAxis("Vertical");

            Vector3 movePlayerKeyboard = transform.right * horizontalMovementKeyboard + transform.forward * verticalMovementKeyboard;

            controller.Move(movePlayerKeyboard * Time.deltaTime * speed);
        }
    }

    /// <summary>
    /// Method to handle the basic physics of the player
    /// </summary>
    void HandlePhysicsInGame() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
