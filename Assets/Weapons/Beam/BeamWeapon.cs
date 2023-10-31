using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWeapon : Weapon
{
    private GameObject projectile;
    private void Awake()
    {
        projectile = weaponType.projectilePrefab;
    }

    public override void Fire()
    {
        if (!onCooldown)
        {
            base.Fire();
            StartCoroutine(BeginCooldown());

            // Create bullet
            GameObject _projectile = Instantiate(projectile, transform.position, transform.rotation, transform);

            _projectile.layer = LayerMask.NameToLayer("Player");

            // Set the projectile weapon type
            Beam beamComponent = _projectile.GetComponentInChildren<Beam>();

            if (beamComponent != null)
                beamComponent.weaponData = weaponType;
            else
                Debug.Log("No Beam Assigned.");
        }
    }
}
