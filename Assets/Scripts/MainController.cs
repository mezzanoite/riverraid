using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
    public static int score;
    public static bool isPlaying = true;

    private GameObject logo;
    private GameObject gameOverScreen;

    public void EndGame() {
        isPlaying = false;

        logo.GetComponent<SpriteRenderer>().enabled = true;
        gameOverScreen.GetComponent<SpriteRenderer>().enabled = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("GameScene");
    }
}
