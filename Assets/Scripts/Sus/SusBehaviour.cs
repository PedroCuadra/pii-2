using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusBehaviour : Entity
{
    public StateMachine<SusBehaviour> stateMachine;
    [System.NonSerialized]
    public bool touchingGround = false;

    [SerializeField]
    public SusIdleState idleState;
    public SusJumpingState jumpState;
    public SusAttackState attackState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<SusBehaviour>(this);

        stateMachine.AddState("idle", idleState);
        stateMachine.AddState("jump", jumpState);
        stateMachine.AddState("attack", attackState);
        stateMachine.SetState("idle");
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();        
    }

    private Collision2D lastCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchingGround = true;
        lastCollision = collision;
    }
}
