using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : BaseWeapon
{

    public GameObject vfxPrefab;
    public override void Fire()
    {

        Instantiate(vfxPrefab, transform.position, Quaternion.identity);
        Debug.Log("LaserWeapon.Fire() called");
    }
}
