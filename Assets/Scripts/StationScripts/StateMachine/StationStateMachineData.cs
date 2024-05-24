using System.Collections.Generic;
using UnityEngine;

namespace StationScripts.StateMachine
{
    public class StationStateMachineData
    {
        private readonly Queue<Vector3> _itemsPositions = new();
        public Queue<Vector3> ItemsPositions => _itemsPositions;

        public void AddItem(Vector3 position) => _itemsPositions.Enqueue(position);
        public Vector3 RemoveItem() => _itemsPositions.Dequeue();
        
    }
}