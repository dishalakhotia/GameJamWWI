using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : BaseWeapon
{
    public override void Fire(Vector3 direction)
    {

        Instantiate(_PageData.vfxPrefab, transform.position, Quaternion.identity);
        Debug.Log("LaserWeapon.Fire() called");
    }
}
