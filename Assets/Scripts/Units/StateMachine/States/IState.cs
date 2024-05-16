using UnityEngine;

namespace Units.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Enter(Vector3 target);
        void Exit();
        void Update();
    }
}