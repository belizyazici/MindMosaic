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

    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _rightTransform;

    private int desiredLane = 1; // 0- left 1 - middle 2 -right
    public float laneDistance = 4.0f;

    
    

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
        
        
    }

    void Update()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log($"DesiredLane: {desiredLane}");
            desiredLane++;
            Debug.Log($"DesiredLane after increment: {desiredLane}");
            if (desiredLane == 3)
            {
                desiredLane = 2;
                Debug.Log($"DesiredLane after 3: {desiredLane}");
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log($"DesiredLane: {desiredLane}");
            desiredLane--;
            Debug.Log($"DesiredLane after decrement: {desiredLane}");
            if (desiredLane == -1)
            {
                desiredLane = 0;
                Debug.Log($"DesiredLane after -1: {desiredLane}");
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            //targetPosition += Vector3.back * laneDistance;
            targetPosition = _leftTransform.position;
        }else  if (desiredLane == 2)
        {
            //targetPosition += Vector3.forward * laneDistance;
            targetPosition = _rightTransform.position;
        }
        var test = Vector3.Lerp(transform.position, targetPosition, 800 * Time.deltaTime) - transform.position;
        var pos = new Vector3(transform.forward.x, transform.forward.y, test.z);
        characterController.Move(pos * runSpeed * Time.deltaTime);
        //characterController.Move(Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime) - transform.position);
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
