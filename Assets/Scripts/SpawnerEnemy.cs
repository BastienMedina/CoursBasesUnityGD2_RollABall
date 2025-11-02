using UnityEngine;
using System.Collections.Generic;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _basicEnemy;
    [SerializeField] private List<Transform> _spawnPointsList;
    [SerializeField] private float _rateOfSpawn = 3f;
    [SerializeField] private Transform _bossSpawnPoint;
    [SerializeField] private GameObject _bossEnemyPrefab;

    private Transform _randomSpawner;
    private int _enemyQuantitySpawn = 99;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnBasicEnemy), 0f, _rateOfSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBossEnemy();
    }

    void SpawnBasicEnemy()
    {
        RandomSpawner();
        GameObject newBasicEnemy = Instantiate(_basicEnemy, _randomSpawner.position, _randomSpawner.rotation);
        _enemyQuantitySpawn += 1;
    }

    void RandomSpawner()
    {
        int randomIndex = Random.Range(0, _spawnPointsList.Count - 1);
        _randomSpawner = _spawnPointsList[randomIndex];
    }

    public void IncreaseRateOfSpawn(float amount)
    {
        _rateOfSpawn -= amount;
    }

    void SpawnBossEnemy()
    {
        if (_enemyQuantitySpawn >= 100)
        {
            GameObject newBossEnemy = Instantiate(_bossEnemyPrefab, _bossSpawnPoint.position, _bossSpawnPoint.rotation);
            _enemyQuantitySpawn = 0;
        }
    }
}
