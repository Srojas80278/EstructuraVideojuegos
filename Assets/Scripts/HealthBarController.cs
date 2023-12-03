using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;

    [SerializeField]
    public UnityEvent<float> OnDamage;

    void Awake()
    {
        OnDamage.AddListener(DecreaseHealth);
       
    }

    public void Initialize(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void DecreaseHealth(float value)
    {
        healthBar.value -= Mathf.Abs(value);
    }

   
}
