using Units.StateMachine;
using UnityEngine;
using BaseScripts;
using UnityEngine.Serialization;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Station _station;
        [SerializeField] private Transform _hand;
        
        private UnitStateMachine _stateMachine;

        public Transform Hand => _hand;
        public Vector3 SpawnPosition { get; private set; }

        private void Awake() => _stateMachine = new UnitStateMachine(this, _station);
        
        private void OnEnable() => SpawnPosition = transform.position;

        private void Update() => _stateMachine.Update();
    }
}