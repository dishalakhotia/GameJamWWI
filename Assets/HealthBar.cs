using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public EnemyHealth targetHealth;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        targetHealth.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        targetHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
