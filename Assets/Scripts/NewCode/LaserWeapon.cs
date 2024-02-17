using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LaserWeapon : BaseWeapon
{
    public int baseDamage;
    public GameObject vfxPrefab;

    public Transform lp;
    public float radius = 5f; 
    public float length = 10f; 
    public int resolution = 36; 
    public LayerMask enemyLayer; 
    public override void Fire()
    {
    
        GameObject objVFX = Instantiate(vfxPrefab, BaseWeaponManager.instance.startPoint.position, Quaternion.identity);

        Raycast();

        //projectileMove.transform.position = BaseWeaponManager.instance.startPoint.position + transform.forward; // Adjust as needed
        //Debug.Log("no swish");
        objVFX.transform.rotation = BaseWeaponManager.instance.startPoint.rotation;
     
       

        //Debug.Log("LaserWeapon.Fire() called");


    }

    private void Raycast()
    {
        Debug.DrawLine(BaseWeaponManager.instance.startPoint.position, BaseWeaponManager.instance.endPoint.position, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(BaseWeaponManager.instance.startPoint.position, transform.up, out hit, length, enemyLayer))
        {
            // Hit something on the enemy layer
            Debug.DrawLine(BaseWeaponManager.instance.startPoint.position, hit.point, Color.red);
            Debug.Log("enemy called");// Draw line to where the ray hit
                                      // Handle hit enemy (e.g., damage them)
        }
        else
        {
            // No hit, draw the ray in the scene
            Debug.DrawLine(BaseWeaponManager.instance.startPoint.position, BaseWeaponManager.instance.endPoint.position, Color.green);
        }


    }

    

}
