using UnityEngine;
using System.Collections.Generic;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _basicEnemy;
    [SerializeField] private List<Transform> _spawnPointsList;
    [SerializeField] private float _rateOfSpawn = 3f;

    private Transform _randomSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnBasicEnemy), 0f, _rateOfSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBasicEnemy()
    {
        RandomSpawner();
        GameObject newBasicEnemy = Instantiate(_basicEnemy, _randomSpawner.position, _randomSpawner.rotation);
    }

    void RandomSpawner()
    {
        int randomIndex = Random.Range(0, _spawnPointsList.Count - 1);
        _randomSpawner = _spawnPointsList[randomIndex];
    }
}
