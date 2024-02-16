using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEWeapon : BaseWeapon
{
    public GameObject vfxPrefab;
    public override void Fire()
    {
        // Instantiate visual effects prefab
        Instantiate(vfxPrefab, transform.position, Quaternion.identity);
        Debug.Log("AOEWeapon.Fire() called");
        // Implement area of effect logic here
        // For example, spherecasting to hit enemies within a radius
    }
}
