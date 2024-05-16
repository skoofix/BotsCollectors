using BaseScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class IdleState : MovementState
    {
        public IdleState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Idle State Enter");
            _station.ItemFound += OnItemFound;
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Idle Exit");
            _station.ItemFound -= OnItemFound;
        }

        public override void Update()
        {
            base.Update();
        }

        private void OnItemFound(Vector3 target)
        {
            StateSwitcher.SwitchState<MoveToState>(target);
        }
    }
}