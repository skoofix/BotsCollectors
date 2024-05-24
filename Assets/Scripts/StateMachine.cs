using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StateMachine<TState> : IStateSwitcher<TState> where TState : IState
{
    protected readonly List<TState> States;
    protected TState CurrentState;

    protected StateMachine()
    {
        States = new List<TState>();
    }

    public void SwitchState<T>() where T : TState
    {
        TState state = States.FirstOrDefault(state => state is T);

        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }

    public void SwitchState<T>(Vector3 target) where T : TState
    {
        TState state = States.FirstOrDefault(state => state is T);

        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter(target);
    }

    public void Update() => CurrentState.Update();
}