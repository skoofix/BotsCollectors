using Units;
using UnityEngine;

namespace StationScripts.StateMachine.States
{
    public class FlagSettingState : IdleState
    {
        private bool _flagSet;

        public FlagSettingState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station, StationStateMachineData data, Flag flag, int unitCreationCost) : base(stateSwitcher, unit, station, data, flag, unitCreationCost) {}

        public override void Enter()
        {
            base.Enter();

            if (Station.CanSetFlag() == false)
                StateSwitcher.SwitchState<WorkState>();
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (IsValidFlagPosition(hit))
                    {
                        SetFlag(hit.point);
                    }
                }
            }
        }

        private bool IsValidFlagPosition(RaycastHit hit) => hit.transform.TryGetComponent(out Platform platform);

        private void SetFlag(Vector3 position)
        {
            Flag.SetPosition(position - new Vector3(0, 0.25f, 0));
            
            if(_flagSet == false)
            {
                Flag.gameObject.SetActive(true);
                _flagSet = true;
            }

            StateSwitcher.SwitchState<FlagActiveState>();
        }
    }
}