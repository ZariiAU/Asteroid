using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public WeaponData weaponData;
    private Rigidbody2D rb;
    private string targetTag = "Enemy";

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * weaponData.speed);
        StartCoroutine(StartLifetime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(targetTag))
        {
            collision.collider.GetComponent<IDamageable>().Damage(weaponData.damage);
            PlayerTracker.Instance.Player.GetComponentInChildren<AudioSource>().PlayOneShot(weaponData.impactSoundEffect);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Destroys the gameObject this component is attached to after duration given by weaponData.lifetime
    /// </summary>
    /// <returns></returns>
    IEnumerator StartLifetime()
    {
        yield return new WaitForSeconds(weaponData.lifetime);
        Destroy(gameObject);
    }
}
