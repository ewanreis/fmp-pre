using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{   public float speed = 6f, turnSmoothTime = 0.1f,jumpHeight = 5f,sprintSpeed = 15f,groundDistance = 0.4f;
    public CharacterController controller;
    public Transform cam, GroundCheck;
    public LayerMask GroundMask;

    float Gravity = -10f ,turnSmoothVelocity;
    bool IsGrounded;
    Vector3 velocity;

    void Update()
    {   float horizontal = Input.GetAxisRaw("Horizontal"),vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0,vertical).normalized;
        IsGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundMask);

        if(IsGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (Input.GetButtonDown("Jump")&& IsGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Gravity);

        velocity.y += Gravity * Time.deltaTime;

        if (direction.magnitude >= 0.1f)
        {   float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y,
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f,angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized*speed*Time.deltaTime);
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
