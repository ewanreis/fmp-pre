using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    public CharacterController controller;
    public Vector3 playerVelocity, move = new Vector3(0, 0, 0);
    public bool groundedPlayer;
    public int playerState;
    public float playerSpeed = 2.0f, jumpHeight = 1.0f, gravityValue = -9.81f;

    enum State
    {
        Idle, // 0 
        Walk, // 1
        Run, // 2
        Jump, // 3
        Aim // 4
    }

    public void PlayerState()
    {
        groundedPlayer = controller.isGrounded;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            
        }
    }
    public void MovePlayer()
    {
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero) gameObject.transform.forward = move;

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer) playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
