using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CollectablePage firstWeapon, secondWeapon, thirdWeapon;
    public BaseWeapon currentlevelweapon1, currentlevelweapon2, currentlevelweapon3;
    public bool Weapon1acquired, weapon2acquired, weapon3acquired;
    public int currentWeaponAcquiredIndex;

    private void Awake()
    {
        instance = this;
        currentWeaponAcquiredIndex = 0;
    }
    private void Update()
    {
        if(currentWeaponAcquiredIndex ==  1)
        {
            if(!Weapon1acquired) 
            {
                Weapon1acquired = true;
                BaseWeaponManager.instance.weapons[currentWeaponAcquiredIndex] = (currentlevelweapon1);


            }

    
        }
       
    }

    public void SetWeaponIndex(int index)
    {
        currentWeaponAcquiredIndex = index;
    }
}
