using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   public float speed = 6f, turnSmoothTime = 0.01f, jumpHeight = 2f, groundDistance = 0.4f, horizontal, vertical;
    public CharacterController controller;
    public Transform cam, GroundCheck;
    public LayerMask GroundMask;
    bool IsGrounded, isIdle, isJumping, isMidair, movingVertical, movingHorizontal;
    float Gravity = -10f , turnSmoothVelocity, targetAngle, angle;
    Vector3 velocity;
    Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update() {
        StateChecker();
    }
    void FixedUpdate() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized, moveDirection;
        IsGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, GroundMask);
        velocity.y = IsGrounded == true && velocity.y < 0 ? -2f : velocity.y;
        velocity.y = Input.GetButtonDown("Jump") && IsGrounded ? Mathf.Sqrt(jumpHeight * -2f * Gravity) : velocity.y;
        velocity.y += Gravity * Time.deltaTime;
        if (direction.magnitude >= 0.1f) {
            targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle, 0f);
            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized*speed*Time.deltaTime);
        } controller.Move(velocity * Time.deltaTime);
    }
    void StateChecker() {
        isMidair = IsGrounded == true ? false : true; // Check if player is midair
        movingHorizontal = horizontal == 0 ? false : true; // Check if player is moving on the horizontal axis
        movingVertical = vertical == 0 ? false : true; // Check if player is moving on the vertical axis
        isIdle = horizontal == 0 && vertical == 0 && IsGrounded == true ? true : false; // Check if player is in idle state
        isJumping = velocity.y > 0 ? true : false; // Check if player is jumping or moving upwards
        anim.SetFloat("verticalMovement",vertical); // Setting the animation parameters
        anim.SetFloat("horizontalMovement",horizontal);
        anim.SetBool("movingHorizontal", movingHorizontal);
        anim.SetBool("movingVertical", movingVertical);
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("midAir", isMidair);
    }
}