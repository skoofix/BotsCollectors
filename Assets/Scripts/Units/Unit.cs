using Units.StateMachine;
using UnityEngine;
using BaseScripts;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        private UnitStateMachine _stateMachine;
        [SerializeField] private Base _base;
        [SerializeField] private CollisionHandler _handler;

        private Vector3 _currentTargetPosition;
        private Vector3 _spawnPosition;
        public Vector3 CurrentTargetPosition => _currentTargetPosition;
        public Vector3 SpawnPosition => _spawnPosition;
        public bool IsBusy => _isBusy;
        
        private bool _isBusy;
        

        private void OnEnable()
        {
            _base.ItemFound += OnItemFound;
            _handler.ApplePickUped += OnPickUped;
        }

        private void OnDisable()
        {
            _base.ItemFound -= OnItemFound;
            _handler.ApplePickUped -= OnPickUped;
        }

        private void Awake()
        {
            _stateMachine = new UnitStateMachine(this);
            _spawnPosition = transform.position;
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private void OnPickUped()
        {
            
        }

        private void OnItemFound(Vector3 target)
        {
            _currentTargetPosition = target;
            _isBusy = true;
        }
    }
}