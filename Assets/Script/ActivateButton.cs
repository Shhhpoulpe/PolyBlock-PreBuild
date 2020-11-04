using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject door;
    public AudioSource myFx;
    public AudioClip ButtonSound;

    public int PositionDoorY;

    public int StopPositionDoorY;
    public bool DoorOpen = true;

    private void Start() {
        
        anim = GetComponent<Animator>();
    }

    private void Update() {
        
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))  // EMPECHE LES DOUBLONS D'ANIMATION
            {
                myFx.PlayOneShot(ButtonSound);
                anim.Play("Take 001");              // PLAY
                anim.Play("Take 001", -1, 0f);      // RESTART
                if (DoorOpen == true)
                {
                    door.transform.Translate(Vector3.up * Time.deltaTime * PositionDoorY);
                }
                if (door.transform.position.y > StopPositionDoorY)
                {
                    DoorOpen = false;
                }
            }
        }
    }
}
