using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    private Animator animator;

    // Ground check fields
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask; // assign Ground layer(s) in Inspector

    bool isGrounded;

    float speedBoost = 1f;
    Vector3 velocity;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (controller == null)
            controller = GetComponent<CharacterController>();

        // If no groundCheck provided, create one at the feet
        if (groundCheck == null)
        {
            groundCheck = new GameObject("GroundCheck").transform;
            groundCheck.SetParent(transform);
            groundCheck.localPosition = new Vector3(0, -controller.height / 2f + 0.1f, 0);
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Ground check using CheckSphere and a LayerMask to avoid detecting the player itself
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask, QueryTriggerInteraction.Ignore);

        if (isGrounded && velocity.y < 0)
        {
            // small negative value to keep controller grounded
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Sprint Code
        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;

        Vector3 move = transform.right * x + transform.forward * z;
        //controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        // Attack Animation
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        // Animator Check Moving
        bool isMoving = (x != 0f || z != 0f);
        animator.SetBool("isMoving", isMoving);

        // Jump Code (use isGrounded from CheckSphere)
        if (Input.GetButtonDown("Jump"))
        {
            if(controller.isGrounded){
                Debug.Log("Jump");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }


        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        
        //controller.Move(velocity * Time.deltaTime);
        move.y = velocity.y;
        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);
    }

    // Debug visualization for the ground check
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
