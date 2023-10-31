using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Weapon Description")]
    public string weaponName;
    [Header("Weapon Stats")]
    public float damage;
    public float speed;
    public float cooldown;
    public float lifetime;
    [Tooltip("Determines the interval that 'ticks' of damage occur on weapons that implement this")]
    public float damageInterval;

    public GameObject projectilePrefab;
    public AudioClip firingSoundEffect;
    public AudioClip impactSoundEffect;
}
