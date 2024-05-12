using System;
using Items;
using UnityEngine;

namespace Units
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] private Unit _unit;

        public event Action ApplePickUped;
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Apple apple))
            {
                Debug.Log("trigerEnter");
                ApplePickUped?.Invoke();
            }
        }
    }
}