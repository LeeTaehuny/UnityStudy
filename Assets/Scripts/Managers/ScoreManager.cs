using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int score;

    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.SetText(score.ToString());
    }
}
