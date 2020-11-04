using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cube;
    public PlayerMotor Player;

    public AudioSource MyFx;

    public AudioClip CrushPlateform;
    private void OnTriggerEnter(Collider other)
    {
        if(Player.MorphType == "Bowling")
        {
            MyFx.PlayOneShot(CrushPlateform);
            Debug.Log("DESTROY");
            Cube.SetActive(false);
        }
        
    }
}
