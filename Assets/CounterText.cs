using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Text))]
public class CounterText : MonoBehaviour
{
    float timeStart = 0;
    float currentTime = 0;

    public float duration = 10;

    public UnityEvent onCountdownEnd;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - timeStart;
        float remainingTime = duration - currentTime;
        if (remainingTime >0)
            GetComponent<Text>().text = "Tiempo: " + remainingTime.ToString("0.00");
        else{
            GetComponent<Text>().text = "0"; 
            onCountdownEnd?.Invoke();
        }
        
    }
}
