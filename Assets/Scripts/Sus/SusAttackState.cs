using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusAttackState : State<SusBehaviour>
{
    public SusAttackState(SusBehaviour target) : base(target)
    {
        target.gameObject.GetComponent<Animator>().SetBool("OpenMouth", true);
    }

    public override State<SusBehaviour> SpecificNext()
    {
        if (_timeInState < 1)
            return this;
        else
            return new SusIdleState(_target);
    }
}
