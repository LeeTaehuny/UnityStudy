using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 minClamp;
    [SerializeField] Vector2 maxClamp;

    Vector2 movement;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        // 입력 시스템으로 전달받은 context를 Vector2 형식으로 읽어서 저장합니다.
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (rb)
        {
            // 현재 위치 저장
            Vector3 currentPosition = rb.position;
            // 이동 위치 저장
            Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y);
            // 다음 위치 계산산
            Vector3 newPosition = currentPosition + moveVector * moveSpeed * Time.fixedDeltaTime;

            // 위치 제한
            newPosition.x = Mathf.Clamp(newPosition.x, minClamp.x, maxClamp.x);
            newPosition.z = Mathf.Clamp(newPosition.z, minClamp.y, maxClamp.y);

            rb.MovePosition(newPosition);
        }
    }
}
