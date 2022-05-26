using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : Entity 
{
  public int coins = 0;

  void OnCollisionEnter2D(Collision2D collision)
  {
    GameObject go = collision.gameObject;
    if(go.tag == "Coin")
    {
      coins++;
      Destroy(go);
    }
  }
}
