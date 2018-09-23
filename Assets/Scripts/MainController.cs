using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

    public static bool isPlaying = false;
    public static int score;

    private GameObject logo;
    private GameObject gameOverScreen;

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isPlaying = true;
        SceneManager.LoadScene("GameSceneValidation");
    }

    public static IEnumerator EndGame()
    {
        isPlaying = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("InitialScene");
    }

}
