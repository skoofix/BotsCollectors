using Items;
using StationScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class UnloadState : MovementState
    {
        public UnloadState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station) {}

        public override void Update()
        {
            base.Update();
            
            MoveTo(Target);

            if (HasReachedTarget())
            {
                DeliverItem();
                StateSwitcher.SwitchState<IdleState>();
            }
        }

        private void DeliverItem()
        {
            if (Unit.Hand.childCount > 0)
            {
                var item = Unit.Hand.GetChild(0);
                SetNewItemParent(item);
                AddScore(item);
                item.gameObject.SetActive(false);
            }

            StateSwitcher.SwitchState<IdleState>();
        }

        private void SetNewItemParent(Transform item) => item.SetParent(null);

        private void AddScore(Transform item)
        {
            if (item.TryGetComponent(out Apple apple))
                Station.AddStationScore(apple.Price);
        }
    }
}