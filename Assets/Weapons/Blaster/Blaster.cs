using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] LayerMask layerMask;
    GameObject projectile;

    private void Awake()
    {
        projectile = weaponType.projectilePrefab;
    }

    public override void Fire()
    {
        base.Fire();

        // Create bullet
        GameObject _projectile = Instantiate(projectile, transform.position, transform.rotation);

        _projectile.layer = LayerMask.NameToLayer("Player");

        // Set the projectile weapon type
        _projectile.TryGetComponent(out Projectile projComponent);
        projComponent.weaponData = weaponType;
    }
}
