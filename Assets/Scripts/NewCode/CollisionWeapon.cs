using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : BaseWeapon
{
    public GameObject vfx;
    public int baseDamage;

    public bool W_IMP;
    public override void Fire()
    {
        EnableAttack();
        Debug.Log("FIRE FIRE");

    }


    void EnableAttack()
    {
        Debug.Log("FIRE FIRE EMABLE");


        if (W_IMP)
        {
            GameObject objVFX = Instantiate(vfx, BaseWeaponManager.instance.startPoint.position, Quaternion.identity);


            ProjectileMove projectileMove = objVFX.GetComponent<ProjectileMove>();
            //projectileMove.transform.position = BaseWeaponManager.instance.startPoint.position + transform.forward; // Adjust as needed
            Debug.Log("no swish");
            projectileMove.transform.rotation = transform.rotation;
            projectileMove.damage = baseDamage;

            RotateTo(objVFX, BaseWeaponManager.instance.endPoint.position);
            Debug.Log("FIRE FIRE ROT");
        }
        else
        {
            GameObject GO = Instantiate(vfx, BaseWeaponManager.instance.startPoint.position, Quaternion.identity);


            collisionbasedprojectile cbp = GO.GetComponentInChildren<collisionbasedprojectile>();
            //projectileMove.transform.position = BaseWeaponManager.instance.startPoint.position + transform.forward; // Adjust as needed
            Debug.Log("yes swish");
            cbp.transform.rotation = transform.rotation;
            cbp.damage = baseDamage;

            RotateTo(GO, BaseWeaponManager.instance.endPoint.position);
            Debug.Log("FIRE FIRE ROT2");
        }

     
    }

    void RotateTo(GameObject obj, Vector3 destination)
    {
        var direction = destination - obj.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }
}

