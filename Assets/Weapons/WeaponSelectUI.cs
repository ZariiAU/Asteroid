using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelectUI : MonoBehaviour
{
    public TMP_Text weaponText;
    public WeaponSelect weaponSelect;

    // Start is called before the first frame update
    void Start()
    {
        weaponSelect.OnWeaponSwitch.AddListener(() => { weaponText.text = "Weapon: " + weaponSelect.selectedWeapon.weaponType.weaponName; });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
