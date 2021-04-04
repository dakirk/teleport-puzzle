using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

public class FirstPerson : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public Transform playerBody;
    public Transform playerCamera;
    float xRotation = 0f;

    void Start() 
    { 
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update ()
    {
        // get the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // clamp x rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    
        // rotate the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    } 
}
