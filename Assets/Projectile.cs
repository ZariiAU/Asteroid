using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public WeaponData weaponData;
    string targetTag = "Enemy";

    private void Update()
    {
        transform.position += transform.up * weaponData.speed;
    }
}
