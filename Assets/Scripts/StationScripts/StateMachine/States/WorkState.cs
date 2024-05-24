using Units;
using UnityEngine;

namespace StationScripts.StateMachine.States
{
    public class WorkState : IdleState
    {
        public WorkState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station, StationStateMachineData data, Flag flag, int unitCreationCost) : base(stateSwitcher, unit, station, data, flag, unitCreationCost) {}

        public override void Update()
        {
            base.Update();
            
            CheckForFlagSetting();
            
            if (Station.GetStationScore() >= UnitCreationCost)
            {
                StateSwitcher.SwitchState<CreateUnitsState>();
            }
        }

        private void CheckForFlagSetting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.transform.root.gameObject == Station.gameObject)
                    {
                        StateSwitcher.SwitchState<FlagSettingState>();
                    }
                }
            }
        }

    }
}