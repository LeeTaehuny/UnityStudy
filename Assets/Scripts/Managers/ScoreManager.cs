using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int score;

    public void UpdateScore(int amount)
    {
        if (gameManager.GameOver) return;

        score += amount;
        scoreText.SetText(score.ToString());
    }
}
