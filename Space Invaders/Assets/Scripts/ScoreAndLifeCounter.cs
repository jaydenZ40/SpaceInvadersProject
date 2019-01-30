using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreAndLifeCounter : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    private int lives = 3;
    private int scores = 0;
    void Update()
    {
        if (PlayerController.isShot)
        {
            if (lives == 0)
                PlayerController.isGameOver = true;
            else
            {
                lives--;
                lifeText.text = "* " + lives;
            }
            PlayerController.isShot = false;
        }
        scores += PlayerController.score;
        scoreText.text = "Score: " + scores;
    }
}