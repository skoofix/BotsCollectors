using System.Collections.Generic;
using Items;
using UnityEngine;

namespace BaseScripts
{
    public class Station : MonoBehaviour
    {

        [SerializeField] private StationScoreCounter _scoreCounter;
        
        private Queue<Vector3> _itemsPositions;

        private void Awake() => _itemsPositions = new Queue<Vector3>();

        private void Update() => ScanTerritory();

        public void AddStationScore(int price) => _scoreCounter.AddScore(price);

        public int GetStationScore() => _scoreCounter.Score;

        public bool TryGetNextItem(out Vector3 itemPosition)
        {
            if (_itemsPositions.Count > 0)
            {
                itemPosition = _itemsPositions.Dequeue();
                return true;
            }

            itemPosition = default;
            return false;
        }

        private void ScanTerritory()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Apple apple) && apple.IsScanned == false)
                {
                    apple.Scanned();
                    _itemsPositions.Enqueue(apple.transform.position);
                }
            }
        }
    }
}