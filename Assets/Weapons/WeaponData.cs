using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    public float fireRate;
    public string weaponName;
    public float damage;
    public float speed;
    public float lifetime;
    public GameObject projectilePrefab;
    public AudioClip firingSoundEffect;
    public AudioClip impactSoundEffect;
}
