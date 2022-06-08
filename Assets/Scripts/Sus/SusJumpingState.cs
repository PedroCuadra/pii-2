using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SusJumpingState : State<SusBehaviour>
{
    private bool _alreadyJumped = false;

    public float jumpForceMin = 40;
    public float jumpForceMax = 60;
    public float angleMin = 30;
    public float angleMax = 60;

    public override void Enter()
    {
        _alreadyJumped = false;
    }

    public override string ConcreteUpdate()
    {
        if (_alreadyJumped)
            if(_target.touchingGround)
                return "idle";
            else
                return null;
        
        float force = Random.Range(jumpForceMin, jumpForceMax);
        float angle = Random.Range(angleMin, angleMax);
        
        float scalex = Mathf.Sign(Random.Range(-1, 1));
        _target.transform.localScale = new Vector3(scalex, 1, 1);

        Vector2 direction = new Vector2(
            Mathf.Cos(angle * Mathf.Deg2Rad) * scalex,
            Mathf.Sin(angle * Mathf.Deg2Rad)
        );
        Vector2 forceVector = direction * force;

        _target.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
        _alreadyJumped = true;
        _target.touchingGround = false;

        return null;
    }
}
