using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float runSpeed = 2.0f;
    public float jumpSpeed = 2.0f;
   
    bool isGrounded;
    private float verticalSpeed;
    public float gravity = 9.81f;
    private CharacterController characterController;

    private int desiredLane = 1; // 0- left 1 - middle 2 -right
    public float laneDistance = 4.0f;

    
    

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
        
        
    }

    void Update()
    {
        characterController.Move(transform.forward * runSpeed * Time.deltaTime);
        Jump();
        
        Vector3 moveVelocity = Vector3.zero;

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else  if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        characterController.Move(Vector3.Lerp(transform.position, targetPosition, -80 * Time.deltaTime) - transform.position);
        
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
            }
        }

        characterController.Move(new Vector3(0, verticalSpeed, 0) * Time.deltaTime);
  
    }

}
