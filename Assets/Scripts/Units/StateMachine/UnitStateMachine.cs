using StationScripts;
using Units.StateMachine.States;

namespace Units.StateMachine
{
    public class UnitStateMachine : StateMachine<IState>
    {
        public UnitStateMachine(Unit unit, Station station)
        {
            States.Add(new IdleState(this, unit, station));
            States.Add(new PickupState(this, unit, station));
            States.Add(new UnloadState(this, unit, station));
            States.Add(new BuildState(this, unit, station));

            CurrentState = States[0];
            CurrentState.Enter();
        }
    }
}