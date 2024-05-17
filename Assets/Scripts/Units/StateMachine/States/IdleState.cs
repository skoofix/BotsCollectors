using BaseScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class IdleState : MovementState
    {
        public IdleState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station) {}

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Idle State Enter");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Idle State Exit");
        }

        public override void Update()
        {
            base.Update();
            
            if (Station.TryGetNextItem(out Vector3 target))
            {
                StateSwitcher.SwitchState<MoveToState>(target);
            }
        }
    }
}