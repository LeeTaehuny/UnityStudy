using UnityEngine;
// 입력 시스템을 사용하기 위한 namespace 추가
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;
    [SerializeField] private float thrustStrength;
    [SerializeField] private float rotationStrength;

    private Rigidbody rb;

    // OnEnable() 함수는 초기화 단계에서 호출되는 함수
    // * Awake() - OnEnable() - Reset() - Start()
    private void OnEnable()
    {
        // InputAction을 활성화
        thrust.Enable();
        rotation.Enable();
    }

    // OnDisable() 함수는 종료 단계에서 OnDestroy() 직전에 호출되는 함수
    private void OnDisable()
    {
        // InputAction을 비활성화
        thrust.Disable();
        rotation.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate() : 피직스와 관련된 업데이트를 진행하는 함수
    // * Update()와 별개로 동작
    private void FixedUpdate()
    {
        if (!rb) return;

        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        // InputAction.IsPressed() : InputAction에 바인딩된 키가 Pressed 이벤트를 받았는지 체크하는 함수
        if (thrust.IsPressed())
        {
            // Time.fixedDeltaTime : FixedUpdate() 함수의 Tick 시간을 가져오는 함수
            // - 방향 * 속도 * DeltaTime 을 통해 프레임에 독립적인 이동 가능
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (rotation.IsPressed())
        {
            float value = rotation.ReadValue<float>();
            if (value > 0)
            {
                ApplyRotation(-rotationStrength);
                
            }
            else if (value < 0)
            {
                ApplyRotation(rotationStrength);
            }
        }
    }

    private void ApplyRotation(float InRotationStrength)
    {
        // 회전 입력이 가해지는 동안은 물리적인 효과를 소멸시키기
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * InRotationStrength * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
