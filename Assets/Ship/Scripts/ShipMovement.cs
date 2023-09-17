using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    ControlHub ch;
    Rigidbody2D rb;
    Vector2 velocity;
    [SerializeField] float acceleration;
    [SerializeField] float boostedAcceleration;
    [SerializeField] float stoppingForce;
    [SerializeField] float rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ch = ControlHub.Instance;
            
        // Add inputs to events
        ch.forwardInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * acceleration; rb.velocity = velocity; });
        ch.backwardInput.AddListener(() => { velocity -= new Vector2(transform.up.x, transform.up.y) * stoppingForce; rb.velocity = velocity; });
        ch.leftInput.AddListener(() => { transform.eulerAngles += Vector3.forward * rotationSpeed; rb.velocity = velocity; });
        ch.rightInput.AddListener(() => { transform.eulerAngles += Vector3.forward * -rotationSpeed; rb.velocity = velocity; });
        ch.boostInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * boostedAcceleration; rb.velocity = velocity; });

    }
    private void FixedUpdate()
    {
        velocity = rb.velocity;
    }
}
