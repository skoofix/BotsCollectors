using Units;
using UnityEngine;

namespace StationScripts.StateMachine.States
{
    public class CreateUnitsState : IdleState
    {
        private bool _isInitialSetup;
        
        public CreateUnitsState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station, StationStateMachineData data, Flag flag, bool isInitialSetup, int unitCreationCost) : base(stateSwitcher, unit, station, data, flag, unitCreationCost)
        {
            _isInitialSetup = isInitialSetup;
        }

        public override void Enter()
        {
            base.Enter();
            
            if (_isInitialSetup)
            {
                CreateUnit();
                _isInitialSetup = false;
            }
            else if (Station.GetStationScore() >= UnitCreationCost)
            {
                Station.RemoveStationScore(UnitCreationCost);
                CreateUnit();
            }
            
            StateSwitcher.SwitchState<WorkState>();
        }
        
        private void CreateUnit()
        {
            Unit unit = Station.Instantiate(Unit, Station.transform.position+new Vector3(0, 1.2f, 0), Quaternion.identity);
            unit.Initialize(Station);
            Station.AddUnit(unit);
        }
    }
}