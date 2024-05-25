using UnityEngine;

namespace Items
{
    public class Apple : MonoBehaviour
    {
        [SerializeField] private int _price;
        public int Price => _price;
    }
}