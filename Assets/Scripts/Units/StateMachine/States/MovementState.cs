using StationScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher<IState> StateSwitcher;
        protected readonly Unit Unit;
        protected readonly Station Station;
        protected Vector3 Target;

        protected MovementState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station)
        {
            StateSwitcher = stateSwitcher;
            Unit = unit;
            Station = station;
        }
        
        public virtual void Enter() {}

        public virtual void Enter(Vector3 target)
        {
            Target = target;
        }
        
        public virtual void Exit() {}
        
        public virtual void Update() { }

        protected void MoveTo(Vector3 target)
        {
            var currentPosition = Unit.transform.position;
            var targetPosition = new Vector3(target.x, currentPosition.y, target.z);
            
            Unit.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Unit.Speed * Time.deltaTime);
        }
        
        protected bool HasReachedTarget()
        {
            var currentPosition = new Vector3(Unit.transform.position.x, 0, Unit.transform.position.z);
            var targetPosition = new Vector3(Target.x, 0, Target.z);
            
            return Vector3.Distance(currentPosition, targetPosition) < 0.3f;
        }
    }
}