using StationScripts;
using Unity.Mathematics;
using UnityEngine;

namespace Units.StateMachine.States
{
    public class BuildState : MovementState
    {
        private Flag _flag;

        public BuildState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station) : base(stateSwitcher, unit, station) {}

        public override void Update()
        {
            base.Update();
            
            MoveTo(Target);

            if (HasReachedTarget())
            {
                BuildNewStation();
            }
        }

        private void BuildNewStation()
        {
            _flag = FindTargetFlag();
            
            if(_flag == null)
                return;
            
            Debug.Log($"Building new station at position: {Target}");
            
            Station.DisableFlagSetting();
            
            Station newStation = Object.Instantiate(Station, Target, quaternion.identity);

            newStation.Initialize(false);
            
            Unit.ChangeStation(newStation);
            Debug.Log("Строю");

            _flag.gameObject.SetActive(false);
            
            StateSwitcher.SwitchState<IdleState>();
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