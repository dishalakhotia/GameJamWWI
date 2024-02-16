using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public PageScriptableObject currentPage; // Currently active page

    public void ShootBullet(Vector3 position, Quaternion rotation, Vector3 direction)
    {
        GameObject bulletObject = ObjectPoolManager.Instance.GetBullet(currentPage.bulletPrefab); // Updated to pass prefab
        bulletObject.transform.position = position;
        bulletObject.transform.rotation = rotation;
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Initialize(direction);
        }
    }
}
