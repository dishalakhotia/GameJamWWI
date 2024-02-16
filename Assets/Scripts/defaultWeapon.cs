using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultWeapon : BaseWeapon
{
    public float baseWeaponBulletSpeed;

    public GameObject baseBulletPrefab;

    public override void Fire()
    {
        GameObject objVFX = Instantiate(baseBulletPrefab, BaseWeaponManager.instance.startPoint.position, Quaternion.identity);
        Bullet bullet = objVFX.GetComponent<Bullet>();
        bullet.transform.position = transform.position + transform.forward; // Adjust as needed
        bullet.transform.rotation = transform.rotation;
        Debug.Log("FIRE FIRE");

    }



    // Start is called before the first frame update
    
}
