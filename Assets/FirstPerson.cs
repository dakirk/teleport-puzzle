using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

public class FirstPerson : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public Transform playerBody;
    public Transform playerCamera;
    public float reachDistance = 5f;
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


        // separate this raycasting to a new script
        int layerMask = (1 << 8) | (1 << 9);

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray playerRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * reachDistance, Color.green);

            if (Physics.Raycast(playerRay, out hit, reachDistance, layerMask))
            {
                Debug.Log($"Hit {hit.transform.name}");
            }
        }
    } 
}
