using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreAndLifeCounter : MonoBehaviour
{
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI level;
    void Update()
    {
        lifeText.text = "* " + PlayerController.lives;
        scoreText.text = "Score: " + PlayerController.score;
        level.text = "Level " + EnemyUnionMovement.levelNum;
    }
}