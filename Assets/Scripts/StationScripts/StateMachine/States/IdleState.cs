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
            if (_data.ItemsPositions.Count > 0)
            {
                target = _data.RemoveItem();
                jobType = JobType.CollectResource;
                return true;
            }

            target = default;
            jobType = default;
            return false;
        }

        private void ScanTerritory()
        {
            Collider[] hitColliders = Physics.OverlapSphere(Station.transform.position, 8);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Apple apple) && apple.IsScanned == false)
                {
                    apple.Scanned();
                    _data.AddItem(apple.transform.position);
                }
            }
        }
    }
}