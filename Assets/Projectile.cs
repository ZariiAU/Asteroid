using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    string targetTag = "Enemy";

    private void Update()
    {
        transform.position = transform.position + transform.forward * weaponData.speed;
    }


}
