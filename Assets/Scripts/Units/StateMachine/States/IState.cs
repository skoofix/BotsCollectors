using UnityEngine;

namespace Units.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}