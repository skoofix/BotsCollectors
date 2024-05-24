using Items;
using StationScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class PickupState : MovementState
    {
        private Apple _targetObject;
        private readonly Transform _handTransform;

        public PickupState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {
            _handTransform = unit.Hand;
        }
        
        public override void Update()
        {
            base.Update();

            MoveTo(Target);

            if (HasReachedTarget())
            {
                _targetObject = FindTargetObject();
                
                if (_targetObject != null)
                    PickupTargetObject(_targetObject);

                StateSwitcher.SwitchState<UnloadState>(Unit.SpawnPosition);
            }
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