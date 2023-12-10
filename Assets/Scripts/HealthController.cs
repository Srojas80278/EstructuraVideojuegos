using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float health;

    [SerializeField]
    float maxHealth = 100.0F;

    HealthBarController _healthBarController;
    PlayerController _playerController;

    Rigidbody2D _rb;

    void Start()
    {
        health = maxHealth;

        _healthBarController = GetComponent<HealthBarController>();
        _healthBarController.Initialize(health);

        _playerController = PlayerController.Instance;

        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0F)
        {
            Destroy(gameObject);
            return;
        }

        _healthBarController.OnDamage.Invoke(damage);

    }
}
