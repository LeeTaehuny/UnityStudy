using UnityEngine;
using UnityEngine.UIElements;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem DestroyVFX;

    void OnTriggerEnter(Collider other)
    {
        if (DestroyVFX)
        {
            Instantiate(DestroyVFX, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }
}
