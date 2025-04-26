using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10.0f;

    void Start()
    {
        PrintInstruction();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // 유니티에는 2가지 입력 방식이 존재 (Old, New)
        // * Old 방식으로 입력을 제어하는 로직은 다음과 같음
        float xValue = Input.GetAxis("Horizontal");
        float yValue = 0.0f;
        float zValue = Input.GetAxis("Vertical");

        Vector3 Velocity;
        Velocity.x = xValue;
        Velocity.y = yValue;
        Velocity.z = zValue;

        // transform은 해당 스크립트가 부착된 GameObject의 Transform 컴포넌트를 가져오는 것을 의미합니다.
        // * Translate() : 현재 위치에 특정 위치값을 더해주는 함수
        transform.Translate(Velocity * Time.deltaTime * moveSpeed);
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the Game!");
    }
}
