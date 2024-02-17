using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionbasedprojectile : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Vector3 offset;
    public int damage;
                      

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false; // Turn off gravity for the bullet
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // Improve collision detection for fast-moving objects
        // Prevent bullet self-collision, assuming bullets are on a specific layer
        Physics.IgnoreLayerCollision(gameObject.layer, gameObject.layer);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed != 0 && rb != null)
        {
            rb.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Debug.Log("hit enemy for" + " " + damage);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Debug.Log("enemyHit");

        }

        speed = 0;

        


        Destroy(gameObject);
    }
}
