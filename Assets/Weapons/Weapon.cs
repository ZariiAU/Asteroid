using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] public WeaponData weaponType;
    protected bool onCooldown;

    /// <summary>
    /// Virtual function that plays a sound and switches the onCooldown boolean.
    /// </summary>
    public virtual void Fire()
    {
        audioSource.PlayOneShot(weaponType.firingSoundEffect);
        StartCoroutine(BeginCooldown());
    }

    public virtual IEnumerator BeginCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(weaponType.cooldown);
        onCooldown = false;
    }
}
