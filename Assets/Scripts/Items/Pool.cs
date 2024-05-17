using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class Pool<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private int _capacity;

        private readonly List<T> _pool = new List<T>();

        protected void Initialize(T[] prefabs)
        {
            for (int i = 0; i < _capacity; i++)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                T spawned = Instantiate(prefabs[randomIndex]);
                spawned.gameObject.SetActive(false);

                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out T result)
        {
            result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

            return result != null;
        }
    }
}