using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float increaseTime = 5.0f;

    GameManager gameManager;
    string PlayerString = "Player";

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == PlayerString && gameManager)
        {
            gameManager.IncreaseTime(increaseTime);
        }
    }
}
