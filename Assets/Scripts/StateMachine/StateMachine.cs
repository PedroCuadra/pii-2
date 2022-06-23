using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StateMachine<T>
{
    protected T _target;
    
    protected string _currentStateName;
    protected State<T> _currentState;
    protected Dictionary<string, State<T>> _states;

    public StateMachine(T target)
    {
        _target = target;
        _currentState = null;
        _states = new Dictionary<string, State<T>>();
    }

    public void AddState(string name, State<T> state){
        state.SetTarget(_target);
        _states.Add(name, state);
    }

    public void SetState(string name){
        if(name == null)
            return;
        if(!_states.ContainsKey(name))
            return;
        if(name!=null && _currentState != null)
            _currentState.Exit();
        _currentStateName = name;
        _currentState = _states[name];
        _currentState.ResetTime();
        _currentState.Enter();
    }

    public void Update(){
        if(_currentState == null)
            return;
        
        string nextState = _currentState.Update();
        SetState(nextState);
    }
}