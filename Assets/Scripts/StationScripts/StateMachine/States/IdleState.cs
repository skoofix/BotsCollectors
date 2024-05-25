using Items;
using Units;
using UnityEngine;

namespace StationScripts.StateMachine.States
{
    public abstract class IdleState : IState, IJobProvider
    {
        protected readonly IStateSwitcher<IState> StateSwitcher;
        protected readonly Unit Unit;
        protected readonly Station Station;
        protected readonly Flag Flag;
        protected readonly int UnitCreationCost;

        private readonly StationStateMachineData _data;

        protected IdleState(IStateSwitcher<IState> stateSwitcher, Unit unit, Station station, StationStateMachineData data, Flag flag, int unitCreationCost)
        {
            StateSwitcher = stateSwitcher;
            Unit = unit;
            Station = station;
            _data = data;
            Flag = flag;
            UnitCreationCost = unitCreationCost;
        }

        public virtual void Enter() {}
        public void Enter(Vector3 target) {}
        public virtual void Exit() {}
        public virtual void Update() => ScanTerritory();

        public virtual bool TryGetNextJob(out Vector3 target, out JobType jobType)
        {
            if (_data.TryGetNextScannedObject(out Apple apple))
            {
                target = apple.transform.position;
                jobType = JobType.CollectResource;
                return true;
            }

            target = default;
            jobType = default;
            return false;
        }

        private void ScanTerritory()
        {
            Collider[] hitColliders = Physics.OverlapSphere(Station.transform.position, 9f);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Apple apple))
                {
                    _data.AddScannedObject(apple);
                }
            }
        }
    }
}