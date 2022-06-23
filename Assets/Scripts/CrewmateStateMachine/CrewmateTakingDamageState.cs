using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewmateTakingDamageState : State<Crewmate>
{
    public float maxTime = 2f;
    
    public override void Enter()
    {
        _target.GetComponent<Collider2D>().enabled = false;
    }

    public override void Exit(){
        _target.GetComponent<Collider2D>().enabled = true;
        ShowRenderers(true);
    }

    public override string ConcreteUpdate()
    {
        if(_timeInState>maxTime)
            return "normal";

        bool show = ( _timeInState % 0.2 ) < 0.1;
        ShowRenderers(show);

        return null;
    }

    private void ShowRenderers(bool show){
        var renderers = _target.GetComponentsInChildren<SpriteRenderer>();

        foreach(var renderer in renderers){
            renderer.enabled = show;
        }
    }
}
