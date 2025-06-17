using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] float[] lanes = { -3.5f, 0.0f, 3.5f };
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance;
    [SerializeField] float coinSpawnChance;

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    LevelGenerator levelGenerator;
    ScoreManager scoreManager;

    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

    void SpawnFence()
    {
        int spawnCount = Random.Range(0, lanes.Length);

        for (int i = 0; i < spawnCount; i++)
        {
            if (availableLanes.Count <= 0) break;

            // 생성할 레인을 선택합니다.
            int seletedLane = SelectLane();

            // 해당 요소에 해당되는 값으로 스폰합니다.
            Vector3 spawnPosition = new Vector3(lanes[seletedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    void SpawnApple()
    {
        if (availableLanes.Count <= 0 || Random.value > appleSpawnChance) return;

        // 생성할 레인을 선택합니다.
        int seletedLane = SelectLane();

        // 해당 요소에 해당되는 값으로 스폰합니다.
        Vector3 spawnPosition = new Vector3(lanes[seletedLane], transform.position.y, transform.position.z);
        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, transform).GetComponent<Apple>();

        if (newApple && levelGenerator)
        {
            newApple.Init(levelGenerator);
        }

    }

    void SpawnCoin()
    {
        if (availableLanes.Count <= 0 || Random.value > coinSpawnChance) return;

        // 생성할 레인을 선택합니다.
        int seletedLane = SelectLane();

        // 1 ~ 5개의 코인을 해당 청크에 랜덤으로 생성합니다.
        int spawnCount = Random.Range(1, 6);

        // Chunk의 사이즈를 통해 코인 사이의 간격을 계산합니다.
        float size = GetChunkSize();
        float interval = size / (spawnCount + 1);

        for (int i = 1; i <= spawnCount; i++)
        {
            // 코인 스폰 z좌표를 계산합니다.
            float positionZ = transform.position.z - (size / 2) + i * interval;

            // 해당 요소에 해당되는 값으로 스폰합니다.
            Vector3 spawnPosition = new Vector3(lanes[seletedLane], transform.position.y, positionZ);
            Coin coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, transform).GetComponent<Coin>();

            if (coin && scoreManager)
            {
                coin.Init(scoreManager);
            }
        }
    }

    int SelectLane()
    {
        // 스폰할 랜덤 인덱스를 추출합니다.
        int randomIndex = Random.Range(0, availableLanes.Count);
        // 생성할 레인을 선택합니다.
        int selectedLane = availableLanes[randomIndex];
        // 사용한 요소를 제거합니다.
        availableLanes.RemoveAt(randomIndex);

        return selectedLane;
    }

    float GetChunkSize()
    {
        // 해당 청크의 사이즈를 통해 코인 사이의 간격을 계산합니다.
        LevelGenerator generator = FindFirstObjectByType<LevelGenerator>();
        if (!generator) return 0.0f;

        return generator.chunkSize;
    }
}
