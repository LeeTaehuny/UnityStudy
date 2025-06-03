using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

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
            Vector3 currentPosition = rb.position;
            Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y);

            Vector3 newPosition = currentPosition + moveVector * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            //Debug.Log(moveVector);
        }
    }
}
