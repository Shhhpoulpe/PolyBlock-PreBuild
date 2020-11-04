using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating3Axes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.PingPong(Time.time, 1f);
        Vector3 axis = new Vector3(1, 1, z);
        transform.Rotate(axis, 1f);
    }
}
