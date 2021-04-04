using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public Color highlightColor = Color.green;
    private float viewDistance = Teleport.reachDistance;
    private Color originalColor;
    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        originalColor = objectMaterial.color;
    }

    void OnMouseOver()
    {
        Transform playerCamera = Camera.main.transform;

        if (Vector3.Distance(transform.position, playerCamera.position) <= viewDistance)
        {
            objectMaterial.color = highlightColor;
        }
        else
        {
            objectMaterial.color = originalColor;
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Exit!");
        objectMaterial.color = originalColor;
    }
}
