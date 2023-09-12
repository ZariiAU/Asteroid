using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] WeaponData weaponType;
    [SerializeField] GameObject projectile;


    public override void Fire()
    {
        // Create bullet
        GameObject _projectile = Instantiate(projectile, transform.position, transform.rotation);
        // Set the projectile weapon type
        _projectile.TryGetComponent(out Projectile projComponent);
        projComponent.weaponData = weaponType;
    }
}
