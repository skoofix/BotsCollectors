using Units.StateMachine;
using UnityEngine;
using BaseScripts;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        private UnitStateMachine _stateMachine;
        [SerializeField] private Station station;
        [SerializeField] private Transform _hand;
        private Vector3 _spawnPosition;

        public Transform Hand => _hand;
        public Vector3 SpawnPosition => _spawnPosition;
        
        private void Awake()
        {
            _stateMachine = new UnitStateMachine(this, station);
        }

        private void OnEnable() => _spawnPosition = transform.position;

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}