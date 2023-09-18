using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField] Weapon selectedWeapon;
    ControlHub ch;

    private void Start()
    {
        ch = ControlHub.Instance;
        ch.fireInput.AddListener(() => { selectedWeapon.Fire(); });
    }
}
