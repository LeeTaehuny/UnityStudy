using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10.0f;
    [SerializeField] float maxOffsetX = 100.0f;
    [SerializeField] float minOffsetX = -100.0f;
    [SerializeField] float maxOffsetY = 100.0f;
    [SerializeField] float minOffsetY = -100.0f;

    [SerializeField] float controlRollFactor = 20.0f;
    [SerializeField] float controlPitchFactor = 20.0f;
    [SerializeField] float rotationSpeed = 10.0f;


    Vector2 Movement;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        // 입력받은 값으로부터 x, y offest을 구해줍니다.
        float xOffset = controlSpeed * Time.deltaTime * Movement.x;
        float yOffset = controlSpeed * Time.deltaTime * Movement.y;

        // 화면을 벗어나지 않는 x, y Value를 구해줍니다.
        float xValue = Mathf.Clamp(transform.localPosition.x + xOffset, minOffsetX, maxOffsetX);
        float yValue = Mathf.Clamp(transform.localPosition.y + yOffset, minOffsetY, maxOffsetY);

        // 로컬 위치를 업데이트합니다.
        transform.localPosition = new Vector3(xValue, yValue, 0.0f);
    }

    private void ProcessRotation()
    {
        // 입력받은 값이 양수면 x, z 값을 -로, 음수면 +로 설정해 회전하는 느낌을 살려줍니다.
        float zValue = controlRollFactor * Movement.x * -1.0f;
        float xValue = controlPitchFactor * Movement.y * -1.0f;

        Quaternion targetQuaternion = Quaternion.Euler(xValue, 0.0f, zValue);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetQuaternion, rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }
}
