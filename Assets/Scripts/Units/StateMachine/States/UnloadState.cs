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
                var apple = GetItemInHand();
                SetNewItemParent(apple.transform);
                AddScore(apple);
                apple.transform.gameObject.SetActive(false);
                Station.ReleaseObject(apple);
            }

            StateSwitcher.SwitchState<IdleState>();
        }

        private void SetNewItemParent(Transform item) => item.SetParent(null);

        private void AddScore(Apple apple) => Station.AddStationScore(apple.Price);

        private Apple GetItemInHand()
        {
            var item = Unit.Hand.GetChild(0);

            return item.TryGetComponent(out Apple apple) ? apple : default;
        }

    }
}