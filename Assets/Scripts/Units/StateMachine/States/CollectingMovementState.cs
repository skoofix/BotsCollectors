using UnityEngine;

namespace Units.StateMachine.States
{
    public class CollectingMovementState : MovementState
    {
        public CollectingMovementState(IStateSwitcher stateSwitcher, Unit unit) : base(stateSwitcher, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("CollectingState");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("CollectingStateExit");
            
        }

        public override void Update()
        {
            MoveToOre(CurrentTargetPosition);
        }

        private void MoveToOre(Vector3 target)
        {
            _unit.transform.position = Vector3.MoveTowards(_unit.transform.position, target, 4f * Time.deltaTime);
        }
    }
}