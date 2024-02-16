using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEWeapon : BaseWeapon
{
    public override void Fire(Vector3 direction)
    {
        // Instantiate visual effects prefab
        Instantiate(_PageData.vfxPrefab, transform.position, Quaternion.identity);
        Debug.Log("AOEWeapon.Fire() called");
        // Implement area of effect logic here
        // For example, spherecasting to hit enemies within a radius
    }
}
