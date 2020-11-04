using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameObject endLevelUI;

    public AudioSource myFx;
    public AudioClip EndLevel;

    public int result;

    private void OnTriggerEnter(Collider Trigger)
    {
        myFx.PlayOneShot(EndLevel);
        Time.timeScale = 0f;
        endLevelUI.SetActive(true);
    }

    
}
