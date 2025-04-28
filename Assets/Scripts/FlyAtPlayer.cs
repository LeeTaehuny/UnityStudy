using Unity.VisualScripting;
using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform PlayerTransform;

    [SerializeField]
    private float MoveSpeed;

    private Vector3 PlayerPosition;

    // Awake() 함수는 Start보다 빠르게 호출됩니다. (게임 시작 시 가장 먼저 호출되는 함수)
    // * 언리얼 엔진의 InitialzeComponents() 함수와 유사
    void Awake()
    {
        // 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }

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
