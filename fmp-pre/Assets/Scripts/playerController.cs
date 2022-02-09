using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   public CharacterController controller;
    public Transform cam, groundCheck, playerBody;
    public float speed = 6, gravity = -9.81f, jumpHeight = 3, turnSmoothTime = 0.1f, groundDistance = 0.4f, mouseSensitivity;
    public LayerMask groundMask;
    float xRotation = 0f;
    Vector3 velocity;
    bool isGrounded;
    float turnSmoothVelocity;

    void Update()
    {
        
        #region Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        #endregion

        #region Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion

        #region Walking
        float horizontal = Input.GetAxisRaw("Horizontal"), vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        #endregion

        #region Turning
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime, mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //transform.rotation = Quaternion.LookRotation(dir);
        playerBody.Rotate(Vector3.up * mouseX);
        #endregion
        
    }
}