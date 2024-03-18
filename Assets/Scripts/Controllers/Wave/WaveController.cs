using Assets.Scripts.Enemies;
using Assets.Scripts.Services;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class WaveController : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] bool test;
# endif

        [SerializeField] EnemyController enemyPrefab;
        [SerializeField] Transform playerTarget;

        [SerializeField] int waveNumber = 5;

        [Header("Spawn Position")]
        [SerializeField] float yPosition;
        [SerializeField] float minXPosition;
        [SerializeField] float maxXPosition;
        [SerializeField] float minZPosition;
        [SerializeField] float maxZPosition;

        [Header("Position Around The Player")]
        [SerializeField] float minXPositionAround;
        [SerializeField] float maxXPositionAround;
        [SerializeField] float minZPositionAround;
        [SerializeField] float maxZPositionAround;

        EnemyFactoryService _enemyFactory;

        private void Awake()
        {
            _enemyFactory = Service.Instance.GetService<EnemyFactoryService>();

            _enemyFactory.Configure(enemyPrefab, playerTarget);
        }

        void Start()
        {
#if UNITY_EDITOR
            if (test) return;
#endif

            SpawnEnemies();
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
                _enemyFactory.Create(GeneratorRandomPosition());
            if (Input.GetKeyDown(KeyCode.F2))
                SpawnEnemies();
        }
# endif

        void SpawnEnemies()
        {
            for (int i = 0; i < waveNumber; i++)
                _enemyFactory.Create(GeneratorRandomPosition());
        }

        bool IsAroundThePlayer(float position)
        {
            if (position < 0)
                if (position > minXPositionAround)
                    return true;
                else if (position < maxXPositionAround)
                    return true;

            return false;
        }

        float GetRandomPosition(float minPosition, float maxPosition)
        {
            float position = Random.Range(minPosition, maxPosition);

            if (IsAroundThePlayer(position))
                return GetRandomPosition(minPosition, maxPosition);

            return position;
        }

        Vector3 GeneratorRandomPosition()
        {
            float randomX = GetRandomPosition(minXPosition, maxXPosition);
            float randomZ = GetRandomPosition(minZPosition, maxZPosition);

            return new Vector3(randomX, yPosition, randomZ);
        }
    }
}