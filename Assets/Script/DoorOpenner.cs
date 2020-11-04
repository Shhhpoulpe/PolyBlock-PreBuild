using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenner : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject Door;
    public bool doorOpen;
    // Update is called once per frame
    void Update()
    {
        if (doorOpen == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 3);
            doorOpen = false;   
        }
    }
}
