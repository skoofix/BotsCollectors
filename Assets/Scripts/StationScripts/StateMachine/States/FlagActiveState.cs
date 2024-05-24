using Units;
using UnityEngine;

namespace StationScripts.StateMachine.States
{
    public class FlagActiveState : IdleState
    {
        private readonly int _targetScore = 5;
        private bool _shouldSwitchToWorkState;

        public FlagActiveState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station, StationStateMachineData data, Flag flag, int unitCreationCost) : base(stateSwitcher, unit, station, data, flag, unitCreationCost) {}

        public override void Update()
        {
            base.Update();
            
            if (_shouldSwitchToWorkState)
            {
                StateSwitcher.SwitchState<WorkState>();
            }
            
            ResetFlagPosition();
        }

        public override bool TryGetNextJob(out Vector3 target, out JobType jobType)
        {
            if (IsScoreCollectionComplete())
            {
                Station.RemoveStationScore(_targetScore);
                target = Flag.Position;
                jobType = JobType.BuildBase;
                _shouldSwitchToWorkState = true;
                Flag.FixPosition();
                return true;
            }
            
            return base.TryGetNextJob(out target, out jobType);
        }

        private void ResetFlagPosition()
        {
            if (Input.GetMouseButtonDown(0) && Flag.IsFixed == false)
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
        
        private bool IsScoreCollectionComplete() => Station.GetStationScore() >= _targetScore;
    }
}