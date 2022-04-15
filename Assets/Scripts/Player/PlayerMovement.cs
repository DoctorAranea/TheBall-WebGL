using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform checkGroundPoint;
    public float speed;
    public float jumpForce;

    private Rigidbody rb;
    private SphereCollider sc;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
    }
    
    void Update()
    {
        CheckGround();
        Movement();
        Jump();
    }

    private void CheckGround()
    {
        checkGroundPoint.position = new Vector3(
            transform.position.x,
            transform.position.y - sc.radius,
            transform.position.z);
        int playerLayer = 1 << 3;
        int ignoreLayer = ~playerLayer;
        isGrounded = Physics.Raycast(transform.position, checkGroundPoint.position - transform.position, sc.radius + .1f, ignoreLayer);
    }

    private void Movement()
    {
        if (!isGrounded)
            return;
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(new Vector3(0, 0, 1) * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(new Vector3(0, 0, -1) * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }
}
