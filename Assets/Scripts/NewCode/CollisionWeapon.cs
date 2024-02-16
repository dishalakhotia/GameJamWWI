using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : BaseWeapon
{
    public GameObject vfx;

    public override void Fire()
    {
        EnableAttack();
        Debug.Log("FIRE FIRE");

    }


    void EnableAttack()
    {
        Debug.Log("FIRE FIRE EMABLE");
        

        GameObject objVFX = Instantiate(vfx, BaseWeaponManager.instance.startPoint.position, Quaternion.identity);

       

        RotateTo(objVFX, BaseWeaponManager.instance.endPoint.position);
        Debug.Log("FIRE FIRE ROT");
    }

    void RotateTo(GameObject obj, Vector3 destination)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}

