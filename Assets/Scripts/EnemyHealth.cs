using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int _health;

    private EnemySpawner spawner;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        
        Debug.Log("enemyDamage");

        if (currentHealth <= 0)
        {
            Die();

            spawner.waves[spawner.waveIndex].enemiesLeft-- ;
        }
    }
    private void Update()
    {
        _health = currentHealth;
    }
    void Die()
    {
        // Optional: Add logic for enemy death, like playing animations or dropping items.
        Destroy(gameObject);
    }
}
