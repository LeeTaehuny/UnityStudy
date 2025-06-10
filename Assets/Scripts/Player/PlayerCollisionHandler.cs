using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown;

    const string hitString = "Hit";
    float cooldownTimer;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        // 애니메이터에 설정된 hit 트리거를 활성화시킵니다.
        animator.SetTrigger(hitString);

        // 시간을 초기화합니다.
        cooldownTimer = 0.0f;
    }
}
