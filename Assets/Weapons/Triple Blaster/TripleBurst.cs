using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBurst : Weapon
{
    [SerializeField] private LayerMask layerMask;
    private GameObject projectile;

    private void Awake()
    {
        projectile = weaponType.projectilePrefab;
    }

    // TODO: Replace with for loop and proper angle calculations.
    public override void Fire()
    {
        if (!onCooldown)
        {
            base.Fire();

            // Create bullet
            GameObject _projectile = Instantiate(projectile, transform.position, transform.rotation);
            GameObject _projectile2 = Instantiate(projectile, transform.position, transform.rotation);
            GameObject _projectile3 = Instantiate(projectile, transform.position, transform.rotation);

            _projectile.transform.Rotate(Vector3.forward, -45);
            _projectile3.transform.Rotate(Vector3.forward, 45);

            _projectile.layer = LayerMask.NameToLayer("Player");
            _projectile2.layer = LayerMask.NameToLayer("Player");
            _projectile3.layer = LayerMask.NameToLayer("Player");

            // Set the projectile weapon type
            _projectile.TryGetComponent(out Projectile projComponent);
            projComponent.weaponData = weaponType;
            _projectile2.TryGetComponent(out Projectile projComponent2);
            projComponent2.weaponData = weaponType;
            _projectile3.TryGetComponent(out Projectile projComponent3);
            projComponent3.weaponData = weaponType;
        }
    }
}
