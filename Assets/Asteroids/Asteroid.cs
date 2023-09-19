using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    Rigidbody2D playerRigidbody;
    bool hasEnteredScreen = false;

    [SerializeField] float damage = 5;
    [SerializeField] float maxForce = 22000;
    [SerializeField] float minForce = 11000;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        playerRigidbody = PlayerTracker.Instance.Player.GetComponent<Rigidbody2D>();

        // Launch the Asteroid at the target.
        LaunchAtTarget2D(playerRigidbody.position);
    }

    private void FixedUpdate()
    {
        if(Utilities.CheckOffScreen(cam, gameObject) == false)
        {
            hasEnteredScreen = true;
        }

        Utilities.LoopOffScreen(cam, rb, hasEnteredScreen);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.collider.TryGetComponent<Damageable>(out Damageable damageable))
                damageable.Damage(damage);
        }
    }

    void LaunchAtTarget2D(Vector2 targetPosition)
    {
        rb.AddForce((targetPosition - rb.position).normalized * Random.Range(minForce, maxForce));
    }

    
}
