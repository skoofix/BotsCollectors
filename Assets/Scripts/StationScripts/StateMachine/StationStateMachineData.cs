using System.Collections.Generic;
using Items;

namespace StationScripts.StateMachine
{
    public class StationStateMachineData
    {
        private readonly ReserveItemsData _reserveItemsData;
        private readonly Queue<Apple> _scannedObjects = new();

        public StationStateMachineData(ReserveItemsData reserveItemsData)
        {
            _reserveItemsData = reserveItemsData;
        }

        public void AddScannedObject(Apple apple)
        {
            if (_reserveItemsData.IsReserved(apple) == false && _scannedObjects.Contains(apple) == false)
            {
                _scannedObjects.Enqueue(apple);
            }
        }
        
        public bool TryGetNextScannedObject(out Apple apple)
        {
            while (_scannedObjects.Count > 0)
            {
                apple = _scannedObjects.Dequeue();
                
                if (_reserveItemsData.IsReserved(apple) == false)
                {
                    ReserveObject(apple);
                    return true;
                }
            }

            apple = null;
            return false;
        }
        
        private void ReserveObject(Apple apple) => _reserveItemsData.ReserveObject(apple);
        
        public void ReleaseObject(Apple apple) => _reserveItemsData.ReleaseObject(apple);
    }
}