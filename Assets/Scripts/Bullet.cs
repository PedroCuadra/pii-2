using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Entity e = collision.gameObject.GetComponent<Entity>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
