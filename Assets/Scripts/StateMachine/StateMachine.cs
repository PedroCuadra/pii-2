using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    private State<T> _currentState;

    public StateMachine(State<T> initialState){
        this._currentState = initialState;
    }

    public void Update(){
        _currentState = _currentState.Next();
    }
}
