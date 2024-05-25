using StationScripts;
using Unity.Mathematics;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class BuildState : MovementState
    {
        private Flag _flag;

        public BuildState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station)
        {}

        public override void Update()
        {
            base.Update();

            MoveTo(Target);

            if (HasReachedTarget())
            {
                RemoveFlag();
                BuildNewStation();
                StateSwitcher.SwitchState<IdleState>();
            }
        }

        private void BuildNewStation()
        {
            Station newStation = Object.Instantiate(Station, Target, quaternion.identity);
            newStation.Initialize(false);
            Unit.ChangeStation(newStation);
        }

        private void RemoveFlag()
        {
            _flag = FindTargetFlag();
            Station.DisableFlagSetting();
            _flag.gameObject.SetActive(false);
        }
        
        private Flag FindTargetFlag()
        {
            Collider[] colliders = Physics.OverlapSphere(Unit.transform.position, 0.3f);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Flag flag))
                {
                    return flag;
                }
            }

            return null;
        }
    }
}