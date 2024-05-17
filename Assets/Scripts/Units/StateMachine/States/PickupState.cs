using BaseScripts;
using Items;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class PickupState : MovementState
    {
        private Apple _targetObject;
        private Transform _handTransform;

        public PickupState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {
            _handTransform = unit.Hand;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Pickup State Enter");
            _targetObject = FindTargetObject();
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Pickup State Exit");
        }

        public override void Update()
        {
            base.Update();

            if (_targetObject != null)
                PickupTargetObject(_targetObject);

            StateSwitcher.SwitchState<MoveToState>(Unit.SpawnPosition);
        }

        private Apple FindTargetObject()
        {
            Collider[] colliders = Physics.OverlapSphere(Unit.transform.position, 0.3f);


            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Apple apple))
                {
                    return apple;
                }
            }

            return null;
        }
        
        private void PickupTargetObject(Apple target)
        {
            target.transform.SetParent(_handTransform);
            target.transform.position = _handTransform.position;
        }
    }
}