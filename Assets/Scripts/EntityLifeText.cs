using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityLifeText : MonoBehaviour
{
    public Entity entity;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Life " + entity.health.ToString() + "/" + entity.maxHealth.ToString();
    }
}
