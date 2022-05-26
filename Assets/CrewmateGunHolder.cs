using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewmateGunHolder : MonoBehaviour
{
    public Transform gunSpawnPoint;
    public GameObject handPrefab;
    public Transform dropTransform;
    private Gun gun;

    void Awake(){
        handPrefab.SetActive(false);
    }

    void Update(){
        if(gun == null)
            return;

        if(Input.GetKeyDown(KeyCode.E))
            gun.Shoot();

        if(Input.GetKeyDown(KeyCode.R))
            DropGun();
    }

    void OnCollisionEnter2D(Collision2D collision){
        GameObject go  = collision.gameObject;
        Gun g = go.GetComponent<Gun>();
        if(g==null)
            return;
        
        go.transform.parent = gunSpawnPoint;
        go.transform.position = gunSpawnPoint.position;
        go.transform.rotation = gunSpawnPoint.rotation;
        go.transform.localScale = gunSpawnPoint.localScale;
        go.GetComponent<BoxCollider2D>().enabled = false;
        gun = g;
        handPrefab.SetActive(true);
    }

    void DropGun(){
        gun.transform.localPosition = dropTransform.localPosition;
        gun.transform.parent = null;
        gun.GetComponent<BoxCollider2D>().enabled = true;
        gun = null;
        handPrefab.SetActive(false);
    }
}
