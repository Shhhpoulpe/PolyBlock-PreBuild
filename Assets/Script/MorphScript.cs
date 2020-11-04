using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphScript : MonoBehaviour
{
    public string MorphType;

    public ParticleSystem TransformationEffect;
    public GameObject FormeNormal, FormeBallon, FormeTriangle, FormeRoue, FormeBowling;

    public AudioSource myFx;
    public AudioClip MorphSound;

    public PlayerMotor Player;
    private CharacterController Controller;
    float ScaleX, ScaleY, ScaleZ;

    public Vector3 startPosition;

    private bool ReleaseButton = true;

    // Start is called before the first frame update
    private void Awake()
    {
        Player = PlayerMotor.FindObjectOfType<PlayerMotor>();
        Controller = Player.GetComponent<CharacterController>();
        startPosition = transform.position;
    }

    private void Update() {
        if (!(Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button2)))
        {
            ReleaseButton = true;
        }
    }

    private void OnTriggerStay(Collider Trigger)
    {
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button2))
        {   
            Player.transform.eulerAngles = new Vector3(0, 0, 0);
            TransformationEffect.Play();
            if (ReleaseButton == true)
            {
                myFx.PlayOneShot(MorphSound);
                ReleaseButton = false;
            }
            switch (MorphType)
            {
                case "Ballon":
                    Debug.Log("Transformation en ballon");
                    DisableAll();
                    FormeBallon.SetActive(true);
                    Player.MorphType = "Ballon";
                    Player.Gravity = -0.5f;
                    Player.JumpForce = 5f;
                    Player.speed = 5f;
                    Controller.height = 1f;
                    break;

                case "Triangle":
                    Debug.Log("Transformation en triangle");
                    DisableAll();
                    FormeTriangle.SetActive(true);
                    Player.MorphType = "Triangle";
                    Player.Gravity = 25.0f;
                    Player.JumpForce = 10.0f;
                    Player.speed = 10.0f;
                    Controller.height = 0f;
                    break;

                case "Roue":
                    Debug.Log("Transformation en roue");
                    DisableAll();
                    FormeRoue.SetActive(true);
                    Player.MorphType = "Roue";
                    Player.Gravity = 25.0f;
                    Player.JumpForce = 14.0f;
                    Player.speed = 20.0f;
                    Controller.height = 0.92f;
                    break;

                case "Bowling":
                    Debug.Log("Transformation en bowling");
                    DisableAll();
                    FormeBowling.SetActive(true);
                    Player.MorphType = "Bowling";
                    Player.Gravity = 40.0f;
                    Player.JumpForce = 8.0f;
                    Player.speed = 7.0f;
                    Controller.height = 0.92f;
                    break;
            }
        }
    }

    private void DisableAll()
    {
        FormeBallon.SetActive(false);
        FormeNormal.SetActive(false);
        FormeTriangle.SetActive(false);
        FormeRoue.SetActive(false);
        FormeBowling.SetActive(false);
    }
}
