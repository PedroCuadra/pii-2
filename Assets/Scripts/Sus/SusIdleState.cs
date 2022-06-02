using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusIdleState : State<SusBehaviour>
{
    private float _randomIdleTime;

    public SusIdleState(SusBehaviour target) : base(target)
    {
        _randomIdleTime = Random.Range(1, 3);
        target.GetComponent<Animator>().SetBool("OpenMouth", false);
    }

    public override State<SusBehaviour> SpecificNext()
    {
        if(_timeInState < _randomIdleTime)
            return this;
        
        float random = Random.Range(0, 100);

        if(random < 20 && _target.touchingGround){
            float scalex = Mathf.Sign(Random.Range(-1, 1));
            _target.transform.localScale = new Vector3(scalex, 1, 1);
            return new SusJumpingState(_target);
        }else if(random >=20 && random <=30){
            return new SusAttackState(_target);
        }else{
            return this;
        }
    }
}
