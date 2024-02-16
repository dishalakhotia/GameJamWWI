using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWeapon : BaseWeapon
{
    public override void Fire(Vector3 direction)
    {
        // Instantiate bullet prefab and set its properties based on weapon data
        GameObject bullet = Instantiate(_PageData.bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * _PageData.bulletSpeed;
        }
    }
}
