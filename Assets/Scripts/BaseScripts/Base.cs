using System;
using Items;
using UnityEngine;

namespace BaseScripts
{
    public class Base : MonoBehaviour
    {
        public event Action<Vector3> ItemFound; 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);
                Debug.Log("Hit");
                
                foreach (var collider in hitColliders)
                {
                    if (collider.TryGetComponent(out Apple apple))
                    {
                        Debug.Log("ItemFound");
                        ItemFound?.Invoke(apple.gameObject.transform.position);
                    }
                }
            }
        }
    }
}