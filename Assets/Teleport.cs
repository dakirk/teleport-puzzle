using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static float reachDistance = 20f;

    // Update is called once per frame
    void Update()
    {
        // seen by raycast if in layers 8 or 9
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
