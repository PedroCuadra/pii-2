using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewmateGunHolder : MonoBehaviour
{
    public Transform gunSpawnPoint;
    private Gun gun;

    void Update(){
        if(Input.GetKeyDown(KeyCode.E) && gun != null){
            gun.Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Gun g = collision.gameObject.GetComponent<Gun>();
        if(g==null)
            return;
        
        collision.gameObject.transform.parent = gunSpawnPoint;
        collision.gameObject.transform.position = Vector3.zero;
        collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gun = g;
    }
}
