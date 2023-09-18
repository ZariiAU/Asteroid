using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected WeaponData weaponType;
    public virtual void Fire()
    {
        audioSource.PlayOneShot(weaponType.firingSoundEffect);
    }
}
