using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem DestroyVFX;

    void OnParticleCollision(GameObject other)
    {
        if (DestroyVFX)
        {
            Instantiate(DestroyVFX, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }
}
