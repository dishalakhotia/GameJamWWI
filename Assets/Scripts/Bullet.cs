using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1.0f; // Bullet life in seconds
    public int damage = 10; // Damage the bullet does to the player
    public float speed= 30f;

   // public delegate void BulletHitHandler(GameObject hitObject);
   // public static event BulletHitHandler OnBulletHit;


    private void Start()
    {

        Invoke("ReturnToPool", bulletLife); // Destroy the bullet after its life expire
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage to the player
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            ReturnToPool(); // Return bullet to pool or destroy
        }
        else if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            ReturnToPool(); // Return bullet to pool or destroy
        }
    }

    void ReturnToPool()
    {
        ObjectPoolManager.Instance.ReturnBullet(gameObject);
        Destroy(gameObject);
    }


    void Update()
    {
        // Move the bullet forward based on its speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        OnBulletHit?.Invoke(other.gameObject);
        Destroy(gameObject); // Destroy the bullet on collision
    }*/

}
