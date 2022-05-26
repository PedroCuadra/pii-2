using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCounterText : MonoBehaviour
{
    public Crewmate crewmate;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Coins " + crewmate.coins.ToString();        
    }
}
