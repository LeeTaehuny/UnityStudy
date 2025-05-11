using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laserObjects;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;

    bool isFire = false;

    void Start()
    {
        // 마우스 커서를 비활성화 합니다.
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in laserObjects)
        {
            ParticleSystem particleSystem = laser.GetComponent<ParticleSystem>();
            if (particleSystem)
            {
                var emissionModule = particleSystem.emission;
                emissionModule.enabled = isFire;
            }
        }
    }

    public void OnFire(InputValue Value)
    {
        isFire = Value.isPressed;
    }

    private void MoveCrosshair()
    {
        // crosshair 위젯의 위치를 마우스 위치로 설정합니다. (Input.mousePosition : 2D 마우스 좌표를 반환)
        crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimLasers()
    {
        foreach (GameObject laser in laserObjects)
        {
            // 발사 방향을 구해줍니다. (목적지 - 현재 위치)
            Vector3 fireDirection = targetPoint.position - transform.position;
            // 회전 값을 구해줍니다. (Quaternion.LookRotation(Vector3) : Vector3을 바라보기 위한 Rotation을 반환해주는 함수)
            Quaternion laserRotation = Quaternion.LookRotation(fireDirection);
            // laser 오브젝트에 회전값을 적용합니다.
            laser.transform.rotation = laserRotation;
        }
    }
}
