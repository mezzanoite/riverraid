using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public static int totalPoints;

    public Text txtScore;
    public Text HighScore;

    private static readonly string HIGH_SCORE = "highscore";

    void Start()
    {
        MainController.score = 0;

        if (!PlayerPrefs.HasKey(HIGH_SCORE))
        {
            updateHighScore(0);
        }
    }

    void Update()
    {

        txtScore.text = MainController.score.ToString();
        HighScore.text = PlayerPrefs.GetInt(HIGH_SCORE).ToString();

        if (MainController.score > PlayerPrefs.GetInt(HIGH_SCORE))
        {
            updateHighScore(MainController.score);
        }
    }

    private void updateHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
}
