using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    private Animator animator;
    public float maxHealth = 100;
    private float currentHealth;
    private bool isDead = false;

    float speedBoost = 1f;
    Vector3 velocity;
    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDead)
            return;
        // Testing damage with debug
    if (Input.GetKeyDown(KeyCode.H))
    {
        Debug.Log("H key pressed - calling TakeDamage(20)");
        TakeDamage(20f);
    }
    if (Input.GetKeyDown(KeyCode.K))
    {
        Debug.Log("K key pressed - calling TakeDamage(999)");
        TakeDamage(999f);
    }
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Sprint Code
        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

        //Attack Animation
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        //Animator Check Moving
        bool isMoving = (x != 0f || z != 0f);
        animator.SetBool("isMoving", isMoving);

        //Jump Code
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(float damage)
        {

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
            else{
                GetHit();
            }
        }

        void GetHit()
        {
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Die");
            animator.SetTrigger("GetHit");
        }

        void Die()
        {
            isDead = true;
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("GetHit");
            animator.SetTrigger("Die");
            controller.enabled = false;
            this.enabled = false;
        }
}
