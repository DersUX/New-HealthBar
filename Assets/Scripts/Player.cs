using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

     public event UnityAction<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void OnDamageButtonClick()
    {
        _currentHealth -= 10f;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void OnHealingButtonClick()
    {
        _currentHealth += 10f;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
