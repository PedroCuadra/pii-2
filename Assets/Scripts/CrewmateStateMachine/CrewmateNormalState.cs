using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewmateNormalState : State<Crewmate>
{
    private string nextState;

    public override void Enter()
    {
        nextState = null;
        _target.onTakeDamage.AddListener(TakeDamageListener);
    }

    public override void Exit(){
        _target.onTakeDamage.RemoveListener(TakeDamageListener);
    }

    public override string ConcreteUpdate()
    {
        return nextState;
    }

    void TakeDamageListener(){
        nextState = "takingDamage";
    }
}
