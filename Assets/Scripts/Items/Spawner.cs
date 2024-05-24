using UnityEngine;

namespace Items
{
    public class Spawner : Pool<Apple>
    {
        [SerializeField] private Apple[] _ObjectTemplates;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _secnodsBetweenSpawn;
        [SerializeField] private bool _isRandomSpawnPosition;

        private float _elapsedTime;

        private void Start() => Initialize(_ObjectTemplates);

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _secnodsBetweenSpawn && TryGetObject(out Apple spawnableObject))
            {
                _elapsedTime = 0;

                SetObject(spawnableObject);
            }
        }

        private void SetObject(Apple spawnableObject)
        {
            spawnableObject.ResetParams();
            spawnableObject.transform.position = _isRandomSpawnPosition ? GetRandomSpawnPosition() : _spawnPoint.position;
            spawnableObject.gameObject.SetActive(true);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float minValue = -7;
            float maxValue = 7;

            float distanceX = Random.Range(minValue, maxValue);
            float distanceZ = Random.Range(minValue, maxValue);

            return new Vector3(distanceX, 1f, distanceZ);
        }
    }
}