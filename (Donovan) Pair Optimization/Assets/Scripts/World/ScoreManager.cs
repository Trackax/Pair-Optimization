using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        if (scoreText != null)
        {
            scoreText.text = score.ToString() + " POINTS";
        }
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString() + " POINTS";
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
