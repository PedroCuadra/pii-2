using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusJumpingState : State<SusBehaviour>
{
    private bool _alreadyJumped = false;
    public SusJumpingState(SusBehaviour target) : base(target)
    {
    }

    public override State<SusBehaviour> SpecificNext()
    {
        if (!_alreadyJumped)
        {
            float force = 40;
            float angle = Random.Range(30, 70);
            Vector2 direction = new Vector2(
                Mathf.Cos(angle * Mathf.Deg2Rad) * Mathf.Sign(_target.transform.localScale.x),
                Mathf.Sin(angle * Mathf.Deg2Rad)
            );
            Vector2 forceVector = direction * force;

            _target.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
            _alreadyJumped = true;
        }
        
        if(_target.touchingGround)
            return new SusIdleState(_target);
        else
            return this;
    }
}
