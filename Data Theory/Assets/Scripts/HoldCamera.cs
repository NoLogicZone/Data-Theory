using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCamera : MonoBehaviour
{
    public GameObject orientation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = orientation.transform.position;
    }
}
