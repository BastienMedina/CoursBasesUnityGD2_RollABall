using UnityEngine;
using System;

public class SpawnerBasic : MonoBehaviour
{

    [SerializeField] private GameObject WallPrefab;
    [SerializeField] private Transform[] SpawnPoints;
    private int SpawnPointsIndex = 0;

    private void OnEnable()
    {
        PlayerCollect.OnTargetCollected += SpawnNewEnemyBasic;
    }

    private void OnDisable()
    {
        PlayerCollect.OnTargetCollected -= SpawnNewEnemyBasic;
    }

    private void SpawnNewEnemyBasic(int score)
    {
        if (SpawnPointsIndex >= SpawnPoints.Length)
        {
            return;
        }
        Instantiate(WallPrefab, SpawnPoints[SpawnPointsIndex].position, SpawnPoints[SpawnPointsIndex].rotation);
        SpawnPointsIndex++;
    }
}
