using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1.0f; // Bullet life in seconds
    public int damage = 10; // Damage the bullet does to the player
    public float speed= 30f;
    private Rigidbody rb;


    // public delegate void BulletHitHandler(GameObject hitObject);
    // public static event BulletHitHandler OnBulletHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Turn off gravity for the bullet
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Improve collision detection for fast-moving objects
        // Prevent bullet self-collision, assuming bullets are on a specific layer
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);

       
    }

    void DeleteMe()
    { Destroy(gameObject); }

    public void Initialize(Vector3 direction)
    {
        rb.velocity = direction * speed;
        
    }

   /* private void Start()
    {

        Invoke("ReturnToPool", bulletLife); // Destroy the bullet after its life expire
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage to the player
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            
        }
        else if (other.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Debug.Log("enemyHit");
           
        }
    }



    void Update()
    {
        // Move the bullet forward based on its speed
        rb.velocity = transform.forward * speed;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        OnBulletHit?.Invoke(other.gameObject);
        Destroy(gameObject); // Destroy the bullet on collision
    }*/

}
