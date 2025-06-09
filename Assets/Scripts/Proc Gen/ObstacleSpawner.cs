using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Transform obstacleParent;
    [SerializeField] List<GameObject> obstaclePrefabs = new List<GameObject>();
    [SerializeField] float spawnWidth;
    [SerializeField] float obstacleSpawnTime;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);

            // 스폰할 오브젝트를 랜덤으로 선택합니다.
            int randomIndex = Random.Range(0, obstaclePrefabs.Count);
            // 스폰 위치(X)를 랜덤으로 선택합니다.
            float randomPositionX = Random.Range(-spawnWidth, spawnWidth);

            // 오브젝트 스폰
            Vector3 spawnPosition = new Vector3(randomPositionX, transform.position.y, transform.position.z);
            Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Random.rotation, obstacleParent);
        }
    }
}
