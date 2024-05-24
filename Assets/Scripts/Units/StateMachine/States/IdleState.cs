using StationScripts;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class IdleState : MovementState
    {
        public IdleState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station) {}

        public override void Update()
        {
            base.Update();
            
            if (Station.TryGetNextJob(out Vector3 target, out JobType jobType))
            {
                switch (jobType)
                {
                    case JobType.CollectResource:
                        StateSwitcher.SwitchState<PickupState>(target);
                        break;
                    case JobType.BuildBase:
                        StateSwitcher.SwitchState<BuildState>(target);
                        break;
                }
            }
        }

    }
}