using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTwoObjects : MonoBehaviour
{
    [SerializeField] private Transform obj1;
    
    [SerializeField] private Transform obj2;

    float initialSize;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        initialSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = obj1.position;
        Vector3 p2 = obj2.position;
        Vector3 middle = (p1 + p2)/2;
        float distance = Vector3.Distance(p1,p2);
        transform.position = new Vector3(
            middle.x,
            middle.y,
            transform.position.z
        );
        cam.orthographicSize = initialSize + distance; 
    }
}
