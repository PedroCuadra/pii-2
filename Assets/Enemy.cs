using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float damage = 2;
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Crewmate crewmate))
        {
            crewmate.TakeDamage(damage);
        }
    }
}
