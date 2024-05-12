using UnityEngine;

namespace Units.StateMachine.States
{
    public class IdleMovementState : MovementState
    {
        public IdleMovementState(IStateSwitcher stateSwitcher, Unit unit) : base(stateSwitcher, unit)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Idle State");
        }

        public override void Exit()
        {
            base.Exit();

            Debug.Log("Idle Exit");
        }

        public override void Update()
        {
            base.Update();

            if (IsBusy)
                StateSwitcher.SwitchState<CollectingMovementState>();
        }
    }
}