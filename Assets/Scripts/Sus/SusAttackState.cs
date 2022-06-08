using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusAttackState : State<SusBehaviour>
{

    public override void Enter()
    {
        _target.gameObject.GetComponent<Animator>().SetBool("OpenMouth", true);
    }

    public override string ConcreteUpdate()
    {        
        if (_timeInState < 1)
            return null;
        else
            return "idle";
    }
}
