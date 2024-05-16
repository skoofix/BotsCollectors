﻿using BaseScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public abstract class MovementState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;
        protected readonly Unit Unit;
        protected readonly Station _station;

        protected MovementState(IStateSwitcher stateSwitcher, Unit unit, Station station)
        {
            StateSwitcher = stateSwitcher;
            Unit = unit;
            _station = station;
        }
        
        public virtual void Enter() {}
        public virtual void Enter(Vector3 target) {}
        public virtual void Exit() {}
        public virtual void Update() { }
        
    }
}