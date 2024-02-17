using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    public delegate void HealthChanged(float currentHealth);
    public event HealthChanged OnHealthChanged;

    public int maxHealth = 100;
    private int currentHealth = 100;
    
    public int _health;

    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);
        Debug.Log("enemyDamage");

        if (currentHealth <= 0)
        {
            Die();
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
