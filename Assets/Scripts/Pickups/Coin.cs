using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int pointAmount = 100;
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        if (scoreManager)
        {
            scoreManager.UpdateScore(pointAmount);
        }
    }
}
