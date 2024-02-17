using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserProj : MonoBehaviour
{
    public GameObject VFX;
    public Transform lp;
    private void Awake()
    {
        Instantiate(VFX ,BaseWeaponManager.instance.startPoint.position, BaseWeaponManager.instance.startPoint.rotation);
        //Debug.Log("no swishaa");
        //objVFX.transform.rotation = BaseWeaponManager.instance.laserPoint.rotation;


        

        //Debug.Log("LaserWeapon.Fireing called");
    }

}
