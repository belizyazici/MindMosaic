using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float runSpeed = 2.0f;
    public float jumpSpeed = 2.0f;
    public float sideSpeed = 2.0f;
    private Rigidbody rb;
    bool isGrounded;
    private float verticalSpeed;
    private float gravity = 9.81f;
    private CharacterController characterController;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
        rb = transform.GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        characterController.Move(transform.forward * runSpeed * Time.deltaTime);
        Jump();
        
    }

    private void Jump()
    {
        isGrounded = characterController.isGrounded;

        if (!isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            verticalSpeed = -gravity * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
            {
                verticalSpeed = Mathf.Sqrt(2f * jumpSpeed * gravity);
                //animator.SetBool("isGrounded", false);
            }
        }

        characterController.Move(new Vector3(0, verticalSpeed, 0) * Time.deltaTime);
        //animator.SetBool("İsGrounded", isGrounded);
  
    }

    private void GoToSide()
    {
        if (Input.GetKey(KeyCode.A)) // left
        {
            characterController.Move(Vector3.left * sideSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D))  // right
        {
            if (transform.position.z < -10)
            {
                characterController.Move(Vector3.right * sideSpeed * Time.deltaTime);
            }
            
        }
    }
}
