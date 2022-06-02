using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    protected T _target;
    protected float _timeInState;

    public State(T target)
    {
        _target = target;
        _timeInState = 0;
    }

    public State<T> Next(){
        _timeInState += Time.deltaTime;
        return this.SpecificNext();        
    }

    public abstract State<T> SpecificNext();
}