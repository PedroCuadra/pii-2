using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : Entity 
{
  public int coins = 0;

  private StateMachine<Crewmate> stateMachine;
  
  private CrewmateNormalState normalState
    = new CrewmateNormalState();
  
  private CrewmateTakingDamageState takingDamageState
    = new CrewmateTakingDamageState();

  void Start(){
    stateMachine = new StateMachine<Crewmate>(this);
    stateMachine.AddState("normal", normalState);
    stateMachine.AddState("takingDamage", takingDamageState);
    stateMachine.SetState("normal");
  }

  void Update(){
    stateMachine.Update();
  }

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
