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
    private float timer = 0f;
    void Start()
    {
        rbEnemies = this.transform.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer % 0.7f < 0.35f)
            rbEnemies.transform.Translate(new Vector2(moveDirection * Time.deltaTime * enemyMovespeed, 0));
        if (moveDown)
        {
            rbEnemies.transform.position -= new Vector3(0, 1, 0);
            moveDown = false;
        }

        if (rbEnemies.transform.childCount == 0)
        {
            //SceneManager.LoadScene(1); // for extra credit
            SceneManager.LoadScene(3);
        }

    }
}
