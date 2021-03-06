using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject lol;
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    AudioSource audioSource;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (velocity.y < 0 && isGrounded)
        {
            velocity.y = -2f;
        }

        if (!gm.reading)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            velocity.y += (gravity * 2) * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);


            if (isGrounded == true && (x != 0f || z != 0f))
            {
                if (audioSource.isPlaying == false)
                {
                    //print("SONANDOOOOOOOOOOOOOOOOOOOOOOOOO");
                    audioSource.Play();

                }
            }
            else
                audioSource.Stop();
        }

    }
}

