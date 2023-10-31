using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public WeaponData weaponData;
    private string targetTag = "Enemy";
    private bool collidingWithEnemy = false;
    private List<Damageable> targets;
    private float elapsedTime;

    private void Start()
    {
        targets = new List<Damageable>();
        StartCoroutine(StartLifetime());
    }

    /// <summary>
    /// Applies a damage over time based on <see cref="WeaponData.damageInterval"/> and <see cref="WeaponData.damage"/>
    /// </summary>
    void DamageOverTime()
    {
        if (collidingWithEnemy)
        {
            if (elapsedTime == weaponData.damageInterval)
            {
                foreach(Damageable target in targets)
                    target.Damage(weaponData.damage);
                PlayerTracker.Instance.Player.GetComponentInChildren<AudioSource>().PlayOneShot(weaponData.impactSoundEffect);
                elapsedTime = 0;
            }
            else if (elapsedTime < weaponData.damageInterval)
                elapsedTime += Time.deltaTime;
        }
    }

    private void Update()
    {
        DamageOverTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            targets.Add(collision.GetComponent<Damageable>());
            collidingWithEnemy = true;
            collision.GetComponent<Damageable>().Damage(weaponData.damage); // Damage the target on contact, then let DamageOverTime take over.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            collidingWithEnemy = false;
            targets.Remove(collision.GetComponent<Damageable>());
        }
    }

    IEnumerator StartLifetime()
    {
        yield return new WaitForSeconds(weaponData.lifetime);
        Destroy(transform.parent.gameObject);
    }
}
