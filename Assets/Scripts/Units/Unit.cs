using Units.StateMachine;
using UnityEngine;
using StationScripts;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Transform _hand;
        [SerializeField] private float _speed;

        private Station _station;
        private UnitStateMachine _stateMachine;

        public Transform Hand => _hand;
        public float Speed => _speed;

        public void Initialize(Station station)
        {
            _station = station;
            SpawnPosition = station.transform.position + new Vector3(0, 1.2f,0);
            _stateMachine = new UnitStateMachine(this, _station);
        }

        public void ChangeStation(Station newStation)
        {
            _station.RemoveUnit(this);
            _station = newStation;
            _station.AddUnit(this);
            Initialize(newStation);
        }
        
        public Vector3 SpawnPosition { get; private set; }

        private void Update() => _stateMachine.Update();
    }
}