using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public CharacterController controller;
    public Vector3 playervelocity;

    public float speed = 5.0f;
    //public float smoothingMovement = 0.5f;
    public float gravity = -9.8f;
    public float vaultHeight = 0.4064f;
    public float jumpHeight = 0.4064f;

    public bool isGrounded;

    public bool isCrouching;
    public bool lerpCrouch;
    public float crouchTimer;
    public bool isSprinting;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (isCrouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0.0f;
            }
        }
    }

    // Functions
    public void ProcessMove(Vector2 input)  // Will receive the input from the InputManager.cs and apply them to the character controler
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playervelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playervelocity.y < 0)
        {
            playervelocity.y = gravity;
        }
        controller.Move(playervelocity * Time.deltaTime);
        Debug.Log(playervelocity.y);
    }

    public void Jump()
    {
        Debug.Log("Jumping");
        if (isGrounded)
        {
            playervelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Vault()
    {
        Debug.Log("Vaulting");
    }

    public void Prone()
    {
        Debug.Log("Proning");

    }

    public void Crouch()
    {
        Debug.Log("Crouching");
        isCrouching = !isCrouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        Debug.Log("Sprinting");
        isSprinting = !isSprinting;
        if (isSprinting)
        {
            speed = 8.0f;
        }
        else
        {
            speed = 5.0f;
        }
    }
}
