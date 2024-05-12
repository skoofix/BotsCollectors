using UnityEngine;

namespace Units.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly Unit _unit;

        protected Vector3 CurrentTargetPosition => _unit.CurrentTargetPosition;
        protected bool IsBusy => _unit.IsBusy;
        
        protected MovementState(IStateSwitcher stateSwitcher, Unit unit)
        {
            StateSwitcher = stateSwitcher;
            _unit = unit;
        }
        
        public virtual void Enter() {}
        public virtual void Exit() {}

        public virtual void Update() { }
        
    }
}