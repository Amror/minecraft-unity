using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update

    public float JumpHeight;
    private Rigidbody rb;
    private bool GroundCollision = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && GroundCollision)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * JumpHeight);
            GroundCollision = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        }
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Layer")
        {
            GroundCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Layer")
        {

            GroundCollision = false;
        }
    }
}
