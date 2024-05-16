using System.Collections.Generic;
using System.Linq;
using BaseScripts;
using Units.StateMachine.States;
using UnityEngine;

namespace Units.StateMachine
{
    public class UnitStateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public UnitStateMachine(Unit unit, Station station)
        {
            _states = new List<IState>()
            {
                new IdleState(this, unit, station),
                new MoveToState(this, unit, station),
                new PickupState(this,unit, station)
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

        public void SwitchState<T>(Vector3 target = default) where T : IState
        {
            IState state = _states.FirstOrDefault(state => state is T);
            
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter(target);
        }

        public void Update() => _currentState.Update();
    }
}