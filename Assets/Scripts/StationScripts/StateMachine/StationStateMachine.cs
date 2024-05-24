using StationScripts.StateMachine.States;
using Units;
using UnityEngine;

namespace StationScripts.StateMachine
{
    public class StationStateMachine : StateMachine<IState>
    {
        public StationStateMachine(Unit unit, Station station, StationStateMachineData data, Flag flag, int unitCreationCost, bool isInitialSetup = true)
        {
            States.Add(new CreateUnitsState(this, unit, station, data, flag, isInitialSetup, unitCreationCost));
            States.Add(new WorkState(this, unit, station, data, flag, unitCreationCost));
            States.Add(new FlagSettingState(this, unit, station, data, flag, unitCreationCost));
            States.Add(new FlagActiveState(this, unit, station, data, flag, unitCreationCost));

            CurrentState = States[0];
            CurrentState.Enter();
        }

        public bool TryGetNextJob(out Vector3 target, out JobType jobType)
        {
            if (CurrentState is IJobProvider jobProvider)
            {
                return jobProvider.TryGetNextJob(out target, out jobType);
            }

            target = default;
            jobType = default;
            return false;
        }
    }
}