using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text highScoreText;

    int previousHighScore;

    public void UpdateText(int score)
    {
        gameOverText.text = $"Game Over\nScore: {score}";
    }

    private void Start() {
        if (PlayerPrefs.HasKey("HighScore")){
            previousHighScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = "Highest: " + previousHighScore.ToString();
        }
    }

    public void UpdateHighest(int score)
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    
}
