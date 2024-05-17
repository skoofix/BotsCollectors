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
            spawnableObject.gameObject.SetActive(true);
            spawnableObject.transform.position = _isRandomSpawnPosition ? GetRandomSpawnPosition() : _spawnPoint.position;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float minValueX = -4;
            float maxValueX = 4;
            float minValueZ = -4.5f;
            float maxValueZ = 0.5f;

            float distanceX = Random.Range(minValueX, maxValueX);
            float distanceZ = Random.Range(minValueZ, maxValueZ);

            return new Vector3(distanceX, 1f, distanceZ);
        }
    }
}