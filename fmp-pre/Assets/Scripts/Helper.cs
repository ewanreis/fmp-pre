using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f, jumpHeight = 1.0f, gravityValue = -9.81f;

    public GameObject player;
    private void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    public void MovePlayer()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
            player.transform.forward = move;

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
