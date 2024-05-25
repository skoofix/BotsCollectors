using System.Collections.Generic;
using Items;
using UnityEngine;

namespace StationScripts
{
    public class ReserveItemsData : MonoBehaviour
    {
        private readonly List<Apple> _reservedObjects = new();

        public void ReserveObject(Apple apple)
        {
            if (IsReserved(apple))
                return;
            
            _reservedObjects.Add(apple);
        }

        public bool IsReserved(Apple apple) => _reservedObjects.Contains(apple);

        public void ReleaseObject(Apple apple) => _reservedObjects.Remove(apple);
    }
}