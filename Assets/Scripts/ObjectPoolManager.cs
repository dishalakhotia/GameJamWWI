using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    public GameObject bulletPrefab;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;
        PreloadBullets(11); // Preload bullets into the pool
    }

    void PreloadBullets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet()
    {
        if (bulletPool.Count == 0) PreloadBullets(10); // Load more bullets if pool is empty
        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
        Destroy(bullet);
    }
}
