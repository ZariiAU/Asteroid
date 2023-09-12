using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public WeaponData weaponData;
    string targetTag = "Enemy";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * weaponData.speed);
        StartCoroutine(StartLifetime());
    }

    private void Update()
    {
        //transform.position += transform.up * weaponData.speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            collision.collider.GetComponent<IDamageable>().Damage(weaponData.damage);
            Destroy(gameObject);
        }
    }

    IEnumerator StartLifetime()
    {
        yield return new WaitForSeconds(weaponData.lifetime);
        Destroy(gameObject);
    }
}
