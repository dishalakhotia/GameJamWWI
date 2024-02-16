using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponManager : MonoBehaviour
{
    public PageData[] weaponDatas;
    public BaseWeapon[] weapons;

    private int currentWeaponIndex = 0;

    void Start()
    {
        InitializeWeapons();
    }

    void Update()
    {
        // Example code to switch between weapons (you can replace this with your own logic)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
            Debug.Log("SwitchWeapon(0)");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }

        // Example code to fire current weapon
        if (Input.GetButtonDown("Fire1"))
        {
            FireCurrentWeapon(Vector3.forward); // Example direction (forward)
            Debug .Log("FireCurrentWeapon(Vector3.forward)");
        }
    }

    void InitializeWeapons()
    {
        weapons = new BaseWeapon[weaponDatas.Length];
        for (int i = 0; i < weaponDatas.Length; i++)
        {
            // Instantiate the appropriate type of weapon based on the data
            GameObject weaponGO = new GameObject("Weapon_" + i);
            weaponGO.transform.SetParent(transform); // Set as child of WeaponManager
            BaseWeapon weapon = CreateWeaponFromData(weaponDatas[i], weaponGO);
            weapons[i] = weapon;
        }
    }

    BaseWeapon CreateWeaponFromData(PageData data, GameObject parent)
    {
        BaseWeapon weapon = null;
        // Instantiate the appropriate type of weapon based on the data
        if (data != null)
        {
            if (data.bulletPrefab != null)
            {
                weapon = parent.AddComponent<CollisionWeapon>();
            }
            else if (data.vfxPrefab != null)
            {
                weapon = parent.AddComponent<LaserWeapon>();
            }
            else
            {
                weapon = parent.AddComponent<AOEWeapon>();
            }
            weapon.Initialize(data);
        }
        return weapon;
    }

    void SwitchWeapon(int index)
    {
        if (index >= 0 && index < weapons.Length)
        {
            currentWeaponIndex = index;
        }
    }

    void FireCurrentWeapon(Vector3 direction)
    {
        if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
        {
            weapons[currentWeaponIndex].Fire(direction);
        }
    }
}
