using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public GameObject GameOverUI;

    public AudioSource MyFx;

    public AudioClip GameOverSound;

    private void OnTriggerEnter(Collider Trigger)
    {
        MyFx.PlayOneShot(GameOverSound);
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }
}
