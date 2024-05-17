using Units.StateMachine;
using UnityEngine;
using BaseScripts;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Station _station;
        [SerializeField] private Transform _hand;
        [SerializeField] private float _speed;
        
        private UnitStateMachine _stateMachine;

        public Transform Hand => _hand;
        public float Speed => _speed;
        
        public Vector3 SpawnPosition { get; private set; }

        private void Awake() => _stateMachine = new UnitStateMachine(this, _station);
        
        private void OnEnable() => SpawnPosition = transform.position;

        private void Update() => _stateMachine.Update();
    }
}