using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1.0f; // Bullet life in seconds
    public int damage = 1; // Damage the bullet does to the player
    public float speed= 30f;
    public delegate void BulletHitHandler(GameObject hitObject);
    public static event BulletHitHandler OnBulletHit;


    private void Start()
    {

        Invoke("ReturnToPool", bulletLife); // Destroy the bullet after its life expire
    }

    void ReturnToPool()
    {
        ObjectPoolManager.Instance.ReturnBullet(gameObject);
    }


    void Update()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnBulletHit?.Invoke(other.gameObject);
        Destroy(gameObject); // Destroy the bullet on collision
    }

}
