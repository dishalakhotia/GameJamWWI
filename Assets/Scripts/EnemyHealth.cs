using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
        Debug.Log("enemyDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optional: Add logic for enemy death, like playing animations or dropping items.
        Destroy(gameObject);
    }
}
