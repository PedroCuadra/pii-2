using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusBehaviour : Entity
{
    public StateMachine<SusBehaviour> stateMachine;
    public bool touchingGround = false;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<SusBehaviour>(new SusIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();        
    }

    private Collision2D lastCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.9f)
        {
            touchingGround = true;
            lastCollision = collision;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision == lastCollision)
        {
            touchingGround = false;
            lastCollision = null;
        }
    }
}
