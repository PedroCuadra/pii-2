using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour
{
    public float damage = 20;
    public float speed = 30;
    public Bullet bullet;
    public float cooldown = 0.5f;
    private float timeSinceLastShoot = 0;

    [SerializeField] int maxAmmo = 10;
    [SerializeField] int currentAmmo = 10;

    [SerializeField] Transform bulletSpawnPoint;

    [SerializeField] AudioSource shootSound;
    [SerializeField] AudioSource reloadSound;
    [SerializeField] AudioSource emptySound;

    public void Shoot(){
        if(timeSinceLastShoot < cooldown)
            return;
        
        if(currentAmmo <= 0){
            emptySound.Play();
            return;
        }

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
        shootSound.Play();
        currentAmmo--;
    }

    void Update(){
        timeSinceLastShoot += Time.deltaTime;
    }

    void Reload(int bullets){
        currentAmmo = Mathf.Min(maxAmmo, bullets);
        reloadSound.Play();
    }
}


