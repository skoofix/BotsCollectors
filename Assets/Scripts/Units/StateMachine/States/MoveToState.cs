using BaseScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class MoveToState : MovementState
    {
        private Vector3 _target;
        private bool _isReturnToSpawn;
        
        public MoveToState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station) {}

        public override void Enter(Vector3 target)
        {
            base.Enter();
            Debug.Log("MoveTo State Enter");
            _target = target;
            _isReturnToSpawn = _target == Unit.SpawnPosition;
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("MoveTo State Exit");
        }

        public override void Update()
        {
            MoveTo(_target);

            if (Vector3.Distance(Unit.transform.position, _target) < 0.1f)
            {
                if (_isReturnToSpawn)
                    StateSwitcher.SwitchState<UnloadState>();
                else
                    StateSwitcher.SwitchState<PickupState>();
            }
        }

        private void MoveTo(Vector3 target)
        {
            Unit.transform.position = Vector3.MoveTowards(Unit.transform.position, target, Unit.Speed * Time.deltaTime);
        }
    }
}                                                                               