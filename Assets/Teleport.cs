using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public static float reachDistance = 20f;

    // Update is called once per frame
    void Update()
    {
        // seen by raycast if in layer 9
        int layerMask = (1 << 8) | (1 << 9);

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray playerRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * reachDistance, Color.green);

            if (Physics.Raycast(playerRay, out hit, reachDistance, layerMask) && hit.collider.gameObject.tag == "TeleportPoint")
            {
                GameObject hitObject = hit.collider.gameObject;
                Debug.Log($"Hit {hitObject.transform.name}");
                //Debug.Log($"Parent '{transform.parent.name}' at position {transform.parent.position}");
                transform.parent.position = hitObject.transform.position + new Vector3(0, 2, 0);
                //Debug.Log($"Parent '{transform.parent.name}' at position {transform.parent.position}");
            }
        }
    }
}
