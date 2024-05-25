using System.Collections.Generic;
using Items;
using StationScripts.StateMachine;
using Units;
using UnityEngine;

namespace StationScripts
{
    public class Station : MonoBehaviour
    {
        [SerializeField] private StationScoreCounter _scoreCounter;
        [SerializeField] private int _unitCreationCost = 3;
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private Flag _flagPrefab;
        [SerializeField] private ReserveItemsData _reserveItemsData;
        
        private StationStateMachine _stateMachine;
        private StationStateMachineData _stateMachineData;
        private List<Unit> _units = new();
        private bool _canSetFlag = true;

        public void Initialize(bool isInitialSetup)
        {
            _flagPrefab = Instantiate(_flagPrefab, transform.position, Quaternion.identity);
            _flagPrefab.gameObject.SetActive(false);
            
            _stateMachineData = new StationStateMachineData(_reserveItemsData);
            _stateMachine = new StationStateMachine(_unitPrefab, this, _stateMachineData, _flagPrefab, _unitCreationCost, isInitialSetup);
        }
        
        private void Update() => _stateMachine.Update();

        public int GetStationScore() => _scoreCounter.Score;

        public void AddStationScore(int score) => _scoreCounter.AddScore(score);

        public void RemoveStationScore(int score) => _scoreCounter.RemoveScore(score);

        public bool TryGetNextJob(out Vector3 target, out JobType jobType) => _stateMachine.TryGetNextJob(out target, out jobType);

        public void AddUnit(Unit unit) => _units.Add(unit);

        public void RemoveUnit(Unit unit) => _units.Remove(unit);
        
        public bool CanSetFlag() => _canSetFlag;

        public void DisableFlagSetting() => _canSetFlag = false;

        public void ReleaseObject(Apple apple) => _stateMachineData.ReleaseObject(apple);
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 9f);
        }
    }
}