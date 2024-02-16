using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    // A dictionary to hold the pool for each bullet type.
    private Dictionary<GameObject, Queue<GameObject>> bulletPools = new Dictionary<GameObject, Queue<GameObject>>();

    void Awake()
    {
        Instance = this;
    }

    // Method to get a bullet from the specified bullet pool
    public GameObject GetBullet(GameObject prefab)
    {
        if (!bulletPools.ContainsKey(prefab))
        {
            bulletPools[prefab] = new Queue<GameObject>();
            PreloadBullets(prefab, 20); // Preload 20 bullets of this type
        }

        if (bulletPools[prefab].Count == 0)
        {
            PreloadBullets(prefab, 10); // Load more bullets if pool is empty
        }

        GameObject bullet = bulletPools[prefab].Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    // Method to return a bullet to its respective pool
    public void ReturnBullet(GameObject bullet, GameObject prefab)
    {
        bullet.SetActive(false);
        if (!bulletPools.ContainsKey(prefab))
        {
            bulletPools[prefab] = new Queue<GameObject>();
        }
        bulletPools[prefab].Enqueue(bullet);
    }

    // Preload bullets into the pool
    void PreloadBullets(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bullet = Instantiate(prefab);
            bullet.SetActive(false);
            bulletPools[prefab].Enqueue(bullet);
        }
    }
}
