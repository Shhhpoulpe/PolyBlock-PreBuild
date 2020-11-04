using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    public ParticleSystem dustLeft;
    public ParticleSystem dustRight;


    public string morphType = "Normal";
    private float verticalVelocity;
    public float gravity = 20.0f;
    public float jumpForce = 14.0f;
    public float speed = 10.0f;
    public AudioSource myFx;
    public AudioClip JumpSound;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckJump();
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);
    }

    public void CheckJump()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;

            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button0))
            {
                verticalVelocity = jumpForce;
                myFx.PlayOneShot(JumpSound);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1)
            {
                dustLeft.Play();
                dustLeft.Emit(10);
                if(morphType == "Roue")
                {
                    transform.Rotate(Vector3.forward * 800.0f * Time.deltaTime);
                    dustLeft.Emit(10);
                }
                if (morphType == "Bowling")
                {
                    transform.Rotate(Vector3.forward * 500.0f * Time.deltaTime);
                    dustLeft.Emit(10);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1)
            {
                dustRight.Play();
                dustRight.Emit(10);

                if (morphType == "Roue")
                {
                    transform.Rotate(Vector3.forward * -800.0f * Time.deltaTime);
                }
                if (morphType == "Bowling")
                {
                    transform.Rotate(Vector3.forward * -500.0f * Time.deltaTime);
                }
            }
        }
        else if (MorphType == "Ballon")
        {
            verticalVelocity -= gravity * Time.deltaTime;
            /*if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                verticalVelocity = jumpForce;
                myFx.PlayOneShot(JumpSound);
            }*/
            transform.Rotate(0, 2, 0);
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            dustRight.Stop();
            dustLeft.Stop();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1)
        {
            if (morphType == "Roue")
            {
                transform.Rotate(Vector3.forward * 800.0f * Time.deltaTime);
            }
            if (morphType == "Bowling")
            {
                transform.Rotate(Vector3.forward * 500.0f * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1)
        {
            if (morphType == "Roue")
            {
                transform.Rotate(Vector3.forward * -800.0f * Time.deltaTime);
            }
            if (morphType == "Bowling")
            {
                transform.Rotate(Vector3.forward * -500.0f * Time.deltaTime);
            }
        }
    }

    public float Gravity { get => gravity; set => gravity = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public string MorphType { get => morphType; set => morphType = value; }
    public float Speed { get => speed; set => speed = value; }
}
