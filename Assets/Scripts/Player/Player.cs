using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int desiredLane = 1; // 0- left 1 - middle 2 - right
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

        // Sağ hareket (D veya Sağ Yön Tuşu)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
            PlayMoveSound(); 
        }
        
        // Sol hareket (A veya Sol Yön Tuşu)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
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

            // Zıplama (W veya Yukarı Yön Tuşu)
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
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