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
    public static bool isGameOver = false;
    public static int score = 0;
    public static int lives = 3;
    void Awake()
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
            isGameOver = false;
            SceneManager.LoadScene(2);
        }
        Physics2D.IgnoreLayerCollision(8, 9);  // ignore the collision between player and enemies
        Physics2D.IgnoreLayerCollision(9, 11);  // ignore the collision between enemies and shields
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            lives--;
            if (lives == 0)
            {
                isGameOver = true;
            }
            Destroy(other.gameObject);
            rb.transform.position = new Vector3(0, -8.5f, 0);
        }
    }
}
