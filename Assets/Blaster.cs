using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : IWeapon
{
    [SerializeField] WeaponData weaponType;
    [SerializeField] GameObject projectile;


    public override void Fire()
    {
        Instantiate(projectile);
    }
}
