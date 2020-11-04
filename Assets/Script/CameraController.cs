using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffset, yOffset, zOffset;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(player.transform.position);
    }
}
