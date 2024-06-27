using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool isGrounded;
    public float speed = 5f;
    public bool Sprinting;

    public float gravity = -20f;
    public float terminalVelocity = -30f;
    public float jumpVelocity = 1.4f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent <CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));
        if (!isGrounded)
        {
            playerVelocity.y += gravity * Time.deltaTime; // apply gravity if the player is not grounded
            if (playerVelocity.y < terminalVelocity)
            {
                playerVelocity.y = terminalVelocity; //make the player not fall too fast
            }
        }

        controller.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }
    
    public void startSprint()
    {
        if (isGrounded)
            speed = 10f;
    }
    public void stopSprint()
    {
            speed = 5f;
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpVelocity * -3.0f * gravity); 
        }
    }
}
