using BaseScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class MoveToState : MovementState
    {
        private Vector3 _target;
        
        public MoveToState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {
        }

        public override void Enter(Vector3 target)
        {
            base.Enter();
            Debug.Log("Collecting State Enter");
            _target = target;
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("CollectingStateExit");

        }

        public override void Update()
        {
            MoveTo(_target);

            if (Mathf.Approximately(Unit.transform.position.magnitude, _target.magnitude))
            {
                StateSwitcher.SwitchState<PickupState>();
            }
        }

        private void MoveTo(Vector3 target)
        {
            Unit.transform.position = Vector3.MoveTowards(Unit.transform.position, target, 4f * Time.deltaTime);
        }
        
    }
}                                                                               