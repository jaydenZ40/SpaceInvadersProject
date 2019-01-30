using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject Bullet;
    public float movespeed = 10f;
    public static bool isFiring = false;
    public static bool enemyIsFiring = false;
    public static bool isGameOver = false;
    public static bool isShot = false; // shotByEnemy()
    public static int score = 0; // add hitEnemy later
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            if (rb.transform.position.x > -14.5)
                rb.transform.Translate(new Vector2(-1 * Time.deltaTime * movespeed, 0));
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if (rb.transform.position.x < 14.5)
                rb.transform.Translate(new Vector2(1 * Time.deltaTime * movespeed, 0));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFiring)
        {
            Instantiate(Bullet, rb.transform.position + new Vector3(0, 1, 0), new Quaternion(0, 0, 0, 0));
            isFiring = true;
        }
        if (isGameOver)
        {
            SceneManager.LoadScene(3);
        }
    }
}
