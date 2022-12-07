using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class State
{
    public Phase phase;
    public State nextState;
    public enum Phase
    {
        ENTER, UPDATE, EXIT
    };
    public virtual void Enter()
    {
        phase = Phase.UPDATE;
    }
    public void SwitchToShell(State state)
    {
        nextState = state;
        phase = Phase.EXIT;
        state.phase = Phase.ENTER;
      
    }

    public virtual void Update() { phase = Phase.UPDATE; }
    public virtual void Exit() { phase = Phase.EXIT; }
    public virtual State Process()
    {
        if (phase == Phase.ENTER) Enter();
        if (phase == Phase.UPDATE) Update();
        if (phase == Phase.EXIT)
        {
            Exit();
           
            return nextState;
        }
        return this;
    }
}
