using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SusIdleState : State<SusBehaviour>
{
    private float _randomIdleTime;
    public float idleTimeMin = 0.2f;
    public float idleTimeMax = 0.5f;
    public float jumpChance = 50;
    public float attackChance = 50;
    public float doNothingChance = 2;

    public override void Enter(){
        _randomIdleTime = Random.Range(idleTimeMin, idleTimeMax);
        _target.GetComponent<Animator>().SetBool("OpenMouth", false);
    }

    public override string ConcreteUpdate()
    {
        if(_timeInState < _randomIdleTime)
            return null;
        
        float random = Random.Range(0, jumpChance + attackChance + doNothingChance);
        
        float sum =0;

        sum += jumpChance;
        if(random < sum && _target.touchingGround)
            return "jump";

        sum += attackChance;
        if (random < sum)
            return "attack";
        
        return null;        
    }
}
