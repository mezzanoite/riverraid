using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public static int totalPoints;

    public Text txtScore;
    public Text HighScore;

    void Start()
    {
        MainController.score = 0;

        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
        }
    }

    void Update()
    {

        txtScore.text = MainController.score.ToString();
        HighScore.text = PlayerPrefs.GetInt("score").ToString();

        if (MainController.score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", MainController.score);
        }
    }
}
