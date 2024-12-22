using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float runSpeed = 7.0f;
    public float jumpSpeed = 4.0f;

    bool isGrounded;
    private float verticalSpeed;
    public float gravity = 9.81f;
    private CharacterController characterController;

    [SerializeField] private Transform _leftTransform;
    [SerializeField] private Transform _rightTransform;

    private int desiredLane = 1; // 0- left 1 - middle 2 -right
    public float laneDistance = 4.0f;

    public AudioSource moveSoundSource; 
    public AudioSource jumpSoundSource; 
    public AudioClip moveClip; 
    public AudioClip jumpClip; 

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
        
        if (moveSoundSource != null)
        {
            moveSoundSource.clip = moveClip;
        }

        if (jumpSoundSource != null)
        {
            jumpSoundSource.clip = jumpClip;
        }
    }

    void Update()
    {
        Jump();

        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
            PlayMoveSound(); 
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
            PlayMoveSound(); 
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition = _leftTransform.position;
        }
        else if (desiredLane == 2)
        {
            targetPosition = _rightTransform.position;
        }
        
        var test = Vector3.Lerp(transform.position, targetPosition, 800 * Time.deltaTime) - transform.position;
        var pos = new Vector3(transform.forward.x, transform.forward.y, test.z);
        characterController.Move(pos * runSpeed * Time.deltaTime);
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
                PlayJumpSound(); 
            }
        }

        characterController.Move(new Vector3(0, verticalSpeed, 0) * Time.deltaTime);
    }

    private void PlayMoveSound()
    {
        if (moveSoundSource != null && moveClip != null)
        {
            moveSoundSource.PlayOneShot(moveClip);
        }
    }

    private void PlayJumpSound()
    {
        if (jumpSoundSource != null && jumpClip != null)
        {
            jumpSoundSource.PlayOneShot(jumpClip);
        }
    }
}
