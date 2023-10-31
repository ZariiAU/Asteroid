using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class used to build new weapon types.
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    public WeaponData weaponType;
    protected bool onCooldown;

    /// <summary>
    /// Virtual function that plays a sound and switches the onCooldown boolean.
    /// </summary>
    public virtual void Fire()
    {
        audioSource.PlayOneShot(weaponType.firingSoundEffect);
        StartCoroutine(BeginCooldown());
    }

    /// <summary>
    /// Toggles the <see cref="onCooldown"/> boolean
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator BeginCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(weaponType.cooldown);
        onCooldown = false;
    }
}
