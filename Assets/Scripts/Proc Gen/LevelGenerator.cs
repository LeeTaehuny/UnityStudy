using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] Transform chunkParent;

    [Header("Level Settings")]
    [SerializeField] int chunkQuantity;
    [SerializeField] public int chunkSize;

    [Header("Physics")]
    [SerializeField] float moveSpeed;
    [SerializeField] float minMoveSpeed = 2.0f;
    [SerializeField] float maxMoveSpeed = 20.0f;
    [SerializeField] float minGravityZ = -22.0f;
    [SerializeField] float maxGravityZ = -2.0f;

    List<GameObject> chunks = new List<GameObject>();

    private void Start()
    {
        // 청크를 생성합니다.
        Init();
    }

    private void Update()
    {
        MoveChunks();
        ReSpawnChunk();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravity = Physics.gravity.z - speedAmount;
            newGravity = Mathf.Clamp(newGravity, minGravityZ, maxGravityZ);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravity);
            cameraController.ChangeCameraFOV(speedAmount);
        }     
    }

    private void Init()
    {
        // 초기 생성되어야 하는 청크들을 생성합니다.
        for (int i = 0; i < chunkQuantity; i++)
        {
            // 스폰 위치 계산
            Vector3 spawnPosition = CalculateSpawnPosition(i);
            // 청크 스폰
            SpawnChunk(spawnPosition);
        }
    }

    private void SpawnChunk(Vector3 spawnPosition)
    {
        // 인스턴스를 생성합니다.
        // * Instantiate(생성할 오브젝트, 스폰 위치, 스폰 각도, 부모 Transform)
        // * 부모 Transform을 비워두면 월드를 부모로 스폰
        GameObject newChunk = Instantiate(chunkPrefab, spawnPosition, Quaternion.identity, chunkParent);

        // 리스트에 추가합니다.
        chunks.Add(newChunk);
    }

    private Vector3 CalculateSpawnPosition(int index)
    {
        // 청크를 생성할 위치를 설정합니다.
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // 오프셋을 설정합니다.
        spawnPosition.z += chunkSize * index;
        return spawnPosition;
    }

    private void MoveChunks()
    {
        foreach (GameObject chunk in chunks)
        {
            Vector3 moveDirection = new Vector3(0.0f, 0.0f, -1.0f);
            chunk.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    private void ReSpawnChunk()
    {
        if (chunks[0].transform.position.z < -10.0f)
        {
            GameObject tmpChunk = chunks[0];

            // 청크 소멸
            chunks.Remove(tmpChunk);
            Destroy(tmpChunk);

            // 청크 생성
            Vector3 spawnPosition = CalculateSpawnPosition(chunks.Count);
            SpawnChunk(spawnPosition);
        }
    }
}
