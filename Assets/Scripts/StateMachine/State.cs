using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State<T>
{
    protected T _target;
    protected float _timeInState = 0;
    protected bool _isPaused = false;

    public float timeInState {
        get { return _timeInState; }
    }

    public State()
    {}

    /// <summary>
    /// Calls the SpecificNext method and returns the next state
    /// only if the state is not paused.
    /// </summary>
    public string Update(){
        if (_isPaused)
            return null;
        else{
            _timeInState += Time.deltaTime;
            return ConcreteUpdate();
        }    
    }
    
    /// <summary>
    /// Returns the name of the next state.
    /// if null, the state machine will not change state.
    /// </summary>
    public abstract string ConcreteUpdate();

    /// <summary>
    /// Set the time in the state to 0.
    /// </summary>
    public void ResetTime(){
        _timeInState = 0;
    }

    /// <summary>
    /// Sets the target of the state.
    /// </summary>
    public void SetTarget(T target){
        this._target = target;
    }

    /// <summary>
    /// Override this method to add
    /// functionality when the machine
    /// enters this state
    /// </summary>
    public virtual void Enter(){
        // override if needed
    }

    /// <summary>
    /// Override this method to add
    /// functionality when the machine 
    /// leaves the state
    /// </summary>
    public virtual void Exit(){
        // override if needed
    }
}