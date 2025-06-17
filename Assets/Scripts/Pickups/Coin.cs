using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int pointAmount = 100;
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        if (scoreManager)
        {
            scoreManager.UpdateScore(pointAmount);
        }
    }
}
