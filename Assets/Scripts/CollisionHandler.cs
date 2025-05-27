using UnityEngine;
using UnityEngine.UIElements;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem DestroyVFX;
    GameSceneManager SceneManager;

    private void Start()
    {
        SceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (DestroyVFX)
        {
            Instantiate(DestroyVFX, transform.position, Quaternion.identity);
        }

        if (SceneManager)
        {
            SceneManager.ReloadLevel();
        }

        Destroy(this.gameObject);
    }
}
