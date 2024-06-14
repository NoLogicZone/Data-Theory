using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [SerializeField] float rotationX;
    [SerializeField] float rotationY;
    [SerializeField] float sensibility = 30f;
    public GameObject orientation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       // rotationX = 150;
      //  rotationY = 150;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensibility;
        rotationY += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensibility;
        transform.localRotation = Quaternion.Euler(Mathf.Clamp(-rotationY, -90, 90), rotationX, 0);
        orientation.transform.rotation = Quaternion.Euler(0, rotationX, 0);
    }
}
