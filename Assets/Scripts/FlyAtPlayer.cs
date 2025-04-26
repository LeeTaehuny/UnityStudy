using Unity.VisualScripting;
using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;

    [SerializeField]
    private float MoveSpeed;

    private Vector3 PlayerPosition;

    void Start()
    {
        // 시작과 동시에 목표 위치 설정
        PlayerPosition = PlayerTransform.position;
    }

    void Update()
    {
        MoveToPlayer();
        DestroyWhenReached();
    }

    void MoveToPlayer()
    {
        // Vector3.MoveTowards(현재 위치, 목표 위치, 이동 속도) : 현재 위치에서 목표 위치까지 이동 속도를 고려해 자동으로 position 계산
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, MoveSpeed * Time.deltaTime);
    }

    void DestroyWhenReached()
    {
        // 현재 위치와 목표 위치를 비교해 일치하는 경우 오브젝트 소멸
        if (transform.position == PlayerPosition)
        {
            Destroy(gameObject);
        }
    }
}
