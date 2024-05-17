using UnityEngine;

namespace Items
{
    public class Apple : MonoBehaviour
    {
        [SerializeField] private int _price;

        public int Price => _price;

        public bool IsScanned { get; private set; }

        public void Scanned() => IsScanned = true;

        public void ResetParams() => IsScanned = false;
    }
}