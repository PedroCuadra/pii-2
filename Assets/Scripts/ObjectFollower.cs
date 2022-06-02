using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform target;

    public Vector3 min;
    public Vector3 max;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, min.x, max.x),
            Mathf.Clamp(target.position.y, min.y, max.y),
            transform.position.z
        );
    }
}
