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
    [SerializeField] float maxVelocity = 0.04f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ch = ControlHub.Instance;
            
        // Add inputs to events
        ch.forwardInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * acceleration; });
        ch.backwardInput.AddListener(() => { velocity -= new Vector2(transform.up.x, transform.up.y) * stoppingForce; });
        ch.leftInput.AddListener(() => { transform.eulerAngles += Vector3.forward * rotationSpeed; });
        ch.rightInput.AddListener(() => { transform.eulerAngles += Vector3.forward * -rotationSpeed; });
        ch.boostInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * boostedAcceleration; });

    }
    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
