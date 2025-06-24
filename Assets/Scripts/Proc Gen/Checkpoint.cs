using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float increaseTime = 5.0f;
    [SerializeField] float decreaseTime = 0.2f;

    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    string PlayerString = "Player";

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerString && gameManager)
        {
            gameManager.IncreaseTime(increaseTime);
            obstacleSpawner.DecreaseObstacleSpawnTime(decreaseTime);
        }
    }
}
