using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreAndLifeCounter : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    void Update()
    {
        lifeText.text = "* " + PlayerController.lives;
        scoreText.text = "Score: " + PlayerController.score;
    }
}