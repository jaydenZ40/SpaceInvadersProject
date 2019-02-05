using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UFOmovement : MonoBehaviour
{
    public float moveSpeed = 7;
    public TextMeshProUGUI UFOscore;
    private float timer = 0;
    void Update()
    {
        this.transform.Translate(new Vector2(UFOController.direction * Time.deltaTime * moveSpeed, 0));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            int point = 50 * Random.Range(2, 7);
            PlayerController.score += point;
            Instantiate(UFOscore, this.transform.position, Quaternion.identity); // wrong position??
            UFOscore.text = point.ToString();
            Invoke("destroyScore", 3f);
            Destroy(other.gameObject);
            PlayerController.isFiring = false;
        }
        Destroy(this.gameObject);
        UFOController.isFlying = false;
    }
    void destroyScore()
    {
        Destroy(UFOscore);
    }
}
