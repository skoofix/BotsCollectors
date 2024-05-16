using BaseScripts;
using Items;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class PickupState : MovementState
    {
        private Transform _targetObject;
        
        public PickupState(IStateSwitcher stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {
        }

        public override void Enter()
        {
            base.Enter();
           _targetObject = FindTargetObjectWithAppleComponent();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();
            
            if (_targetObject != null)
            {
                _targetObject.SetParent(Unit.transform);
                
                _targetObject.position = Unit.Hand.position;
                
                StateSwitcher.SwitchState<MoveToState>(Unit.SpawnPosition);
            }
            else
            {
              Debug.Log("Bug");
            } 
        }
        
        private Transform FindTargetObjectWithAppleComponent()
        {
            Collider[] colliders = Physics.OverlapSphere(Unit.transform.position, 1f);
            
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Apple apple))
                {
                    return apple.transform;
                }
            }
            return null;
        }
    }
}