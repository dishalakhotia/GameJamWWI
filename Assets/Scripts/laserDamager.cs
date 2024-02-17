using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDamager : MonoBehaviour
{
    public int damage;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            collision.gameObject.GetComponent<EnemyHealth>()?.TakeDamage(damage);
            Debug.Log("enemyHit");
            Destroy(gameObject, 1f);
        }
    }
}
