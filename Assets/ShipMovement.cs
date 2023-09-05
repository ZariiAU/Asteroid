using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 velocity;
    [SerializeField] float acceleration;
    [SerializeField] float stoppingForce;
    [SerializeField] float rotationSpeed;
    [SerializeField] float maxVelocity = 0.04f;

    // Update is called once per frame
    void Update()
    {
        MoveShip();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void MoveShip()
    {
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector2(transform.up.x, transform.up.y) * acceleration;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y -= stoppingForce;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.forward * -rotationSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed;
        }
        
    }
}
