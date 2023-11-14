using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Contains data for Asteroid collisions and behaviours
/// </summary>
public class Asteroid : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    private Rigidbody2D playerRigidbody;
    private Damageable damageable;

    [SerializeField] private float damage = 5;
    [SerializeField] private float maxForce = 22000;
    [SerializeField] private float minForce = 11000;
    private Vector2 vel;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerRigidbody = PlayerTracker.Instance.Player.GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
        damageable.OnDeath.AddListener(() => { rb.velocity = Vector2.zero; rb.position = Vector2.zero; });
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

    /// <summary>
    /// Adds a force towards <paramref name="targetPosition"/> with a magnitude between <see cref="minForce"/> and <see cref="maxForce"/>
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="targetPosition"></param>
    public void LaunchAtTarget2D(Rigidbody2D rb, Vector3 targetPosition)
    {
        rb.AddForce((targetPosition - rb.transform.position).normalized * Random.Range(minForce, maxForce));
        //Debug.DrawRay(targetPosition, rb.transform.position, Color.red, 10);
    }

    
}
