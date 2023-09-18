using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSelect : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    public Weapon selectedWeapon;
    public UnityEvent OnWeaponSwitch;
    ControlHub ch;

    private void Start()
    {
        ch = ControlHub.Instance;
        ch.fireInput.AddListener(() => { selectedWeapon.Fire(); });
        ch.upScrollInput.AddListener(() => { SwitchWeapon(); });

        foreach(Weapon weapon in GetComponents<Weapon>())
        {
            weapons.Add(weapon);
        }
    }

    void SwitchWeapon()
    {
        if(weapons.IndexOf(selectedWeapon) + 1 > weapons.Count - 1)
        {
            selectedWeapon = weapons[0];
            OnWeaponSwitch.Invoke();
        }
        else
        {
            selectedWeapon = weapons[weapons.IndexOf(selectedWeapon) + 1];
            OnWeaponSwitch.Invoke();
        }
    }
}
