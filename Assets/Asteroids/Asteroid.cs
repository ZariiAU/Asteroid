using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    Rigidbody2D playerRigidbody;

    [SerializeField] float damage = 5;
    [SerializeField] float maxForce = 22000;
    [SerializeField] float minForce = 11000;
    [SerializeField] Vector2 vel;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerRigidbody = PlayerTracker.Instance.Player.GetComponent<Rigidbody2D>();
        
        // Launch the Asteroid at the target.
        //LaunchAtTarget2D(rb, playerRigidbody.position);
    }

    private void Update()
    {
        vel = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                damageable.Damage(damage);
        }
    }

    public void LaunchAtTarget2D(Rigidbody2D rb, Vector3 targetPosition)
    {
        rb.AddForce((targetPosition - rb.transform.position).normalized * Random.Range(minForce, maxForce));
        //Debug.DrawRay(targetPosition, rb.transform.position, Color.red, 10);
    }
}
