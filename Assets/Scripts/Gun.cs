using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 20;
    public float speed = 30;
    public Bullet bullet;
    public float cooldown = 0.5f;
    private float timeSinceLastShoot = 0;

    public Transform bulletSpawnPoint;

    public void Shoot(){
        if(timeSinceLastShoot < cooldown)
            return;

        Transform b = bulletSpawnPoint;
        GameObject bulletInstance = Instantiate(bullet.gameObject, b.position, b.rotation);
        bulletInstance.GetComponent<Bullet>().damage = damage;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    void Update(){
        timeSinceLastShoot += Time.deltaTime;
    }
}


