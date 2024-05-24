using UnityEngine;

public interface IStateSwitcher<TState> where TState : IState
{
    void SwitchState<T>() where T : TState;
    void SwitchState<T>(Vector3 target = default) where T : TState;
}