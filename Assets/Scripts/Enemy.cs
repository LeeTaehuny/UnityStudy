using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem DestroyVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;

    Scoreboard scoreboard;

    void Start()
    {
        // 월드 상에 존재하는 Scoreboard 타입의 첫 번째 오브젝트를 반환하는 함수
        // * 언리얼의 GetActorOfClass()와 동일한 방법 (FindFirstObjectsByType : 붙으면 모든 액터 반환환)
        // * 비용이 많이 들지만 Start()에서 한 번 수행하는 것은 괜찮은 방법
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            if (scoreboard)
            {
                scoreboard.IncreaseScore(scoreValue);
            }

            if (DestroyVFX)
            {
                Instantiate(DestroyVFX, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
