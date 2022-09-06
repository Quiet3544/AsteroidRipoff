using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIUpdater : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text healthText;
    public GameObject endGame;
    public void Start()
    {
        score = 0;
        PlayerMovementScript.health = 5;
        endGame.SetActive(false);

    }
    void Update()
    {
        if (score != -1)
        {
            scoreText.text = score.ToString();
        }
        if (PlayerMovementScript.health != -1)
        {
            healthText.text = PlayerMovementScript.health.ToString();
        }
        if (PlayerMovementScript.health == 0)
        {
            endGame.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }

}