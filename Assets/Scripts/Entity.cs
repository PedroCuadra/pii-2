using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public UnityEvent onDeath;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }

    public void Die(){
        Destroy(gameObject, 0.5f);
    }
}
