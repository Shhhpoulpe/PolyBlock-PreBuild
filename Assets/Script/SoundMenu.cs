using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{

    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    // Start is called before the first frame update


    public void HoverSound()
    {
        myFx.PlayOneShot (hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot (clickFx);
    }
}
