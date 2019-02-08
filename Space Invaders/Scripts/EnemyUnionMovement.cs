using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyUnionMovement : MonoBehaviour
{
    public Rigidbody2D rbEnemies;
    public float enemyMovespeed = 1f;
    public static int moveDirection = 1;
    public static bool moveDown = false;
    public static int levelNum = 1;
    private float timer = 0f;
    void Start()
    {
        rbEnemies = this.transform.GetComponent<Rigidbody2D>();
        rbEnemies.transform.position = new Vector3(0, -levelNum + 1, 0);
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        enemyMovespeed = 1 + timer / 40;
        if (timer % 0.7f < 0.35f)
            rbEnemies.transform.Translate(new Vector2(moveDirection * Time.deltaTime * enemyMovespeed, 0));
        if (moveDown)
        {
            rbEnemies.transform.position -= new Vector3(0, 1, 0);
            moveDown = false;
        }

        if (rbEnemies.transform.childCount == 0)
        {
            int tempScore = PlayerController.score;
            SceneManager.LoadScene(1);
            //SceneManager.LoadScene(3); // for original version
            rbEnemies.transform.position.Set(0, -levelNum + 1 , 0);
            PlayerController.score = tempScore;
            PlayerController.lives++;
            levelNum++;
        }

    }
}
