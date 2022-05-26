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
        GameObject bulletInstance = Instantiate(bullet.gameObject, b.position, transform.rotation);

        bulletInstance.transform.parent = b;
        bulletInstance.transform.localScale = b.localScale;
        bulletInstance.transform.localPosition = Vector3.zero;
        bulletInstance.GetComponent<Bullet>().damage = damage;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(
            speed * transform.lossyScale.x,
            0,
            0
        );
        bulletInstance.transform.parent = null;
    }

    void Update(){
        timeSinceLastShoot += Time.deltaTime;
    }
}


