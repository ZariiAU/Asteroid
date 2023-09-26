using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private ControlHub ch;
    private Rigidbody2D rb;
    private Vector2 velocity;
    [SerializeField] private float acceleration;
    [SerializeField] private float boostedAcceleration;
    [SerializeField] private float stoppingForce;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ch = ControlHub.Instance;
            
        // Add inputs to events
        ch.forwardInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * acceleration * Time.deltaTime; rb.velocity = velocity; });
        ch.backwardInput.AddListener(() => { velocity -= new Vector2(transform.up.x, transform.up.y) * stoppingForce * Time.deltaTime; rb.velocity = velocity; });
        ch.leftInput.AddListener(() => { transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime; rb.velocity = velocity; });
        ch.rightInput.AddListener(() => { transform.eulerAngles += Vector3.forward * -rotationSpeed * Time.deltaTime; rb.velocity = velocity; });
        ch.boostInput.AddListener(() => { velocity += new Vector2(transform.up.x, transform.up.y) * boostedAcceleration * Time.deltaTime; rb.velocity = velocity; });

    }
    private void Update()
    {
        velocity = rb.velocity;
    }
}
