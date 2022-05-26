using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor = 0.9f;

    void LateUpdate()
    {
        Vector3 cameraPosition = cameraTransform.position;
        Vector3 newpos = new Vector3(
            cameraPosition.x * parallaxFactor,
            cameraPosition.y * parallaxFactor, 
            transform.position.z
        );
        transform.position = newpos;
    }

}
