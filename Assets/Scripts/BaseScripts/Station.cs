using System;
using Items;
using UnityEngine;

namespace BaseScripts
{
    public class Station : MonoBehaviour
    {
        public event Action<Vector3> ItemFound;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScanTerritory();
            }
        }

        private void ScanTerritory()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);

            foreach (var collider in hitColliders)
            {
                if (collider.TryGetComponent(out Apple apple))
                {
                    ItemFound?.Invoke(apple.transform.position);
                }
            }
        }
    }
}