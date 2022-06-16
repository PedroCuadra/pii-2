using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRepeat : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Vector3 _newPos;
    private float _initialTime;

    public Vector3 target;
    public float time = 1;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _initialTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        float currentTime = (Time.time - _initialTime) % time;
        
        _newPos = Vector3.Lerp(_initialPosition,target,currentTime/time);
    }

    void FixedUpdate(){
        transform.position = _newPos;
    }
}
