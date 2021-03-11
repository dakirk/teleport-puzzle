using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 30;
    public float moveSpeed = 10f;
    private Vector3 motion;
    private Rigidbody rb;

    public Transform trackedObject;
    private GameObject ahead;
    private MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _renderer = trackedObject.gameObject.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = motion * speed * Time.deltaTime;
        //KeyboardMovement();
    }

    void KeyboardMovement ()
    {
        Vector3 dir = new Vector3(0, 0, 0);
    
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
    
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
