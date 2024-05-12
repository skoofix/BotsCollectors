using System.Collections.Generic;
using System.Linq;
using Units.StateMachine.States;

namespace Units.StateMachine
{
    public class UnitStateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public UnitStateMachine(Unit unit)
        {
            _states = new List<IState>()
            {
                new IdleMovementState(this, unit),
                new CollectingMovementState(this, unit)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);
            
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Update() => _currentState.Update();
    }
}