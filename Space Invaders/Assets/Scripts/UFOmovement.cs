using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UFOmovement : MonoBehaviour
{
    public float moveSpeed = 7;

    void Start()
    {
        
    }
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
            Destroy(other.gameObject);
            PlayerController.isFiring = false;
            UFOkillScore.points = point;
            UFOkillScore.UFOisKilled = true;
            UFOkillScore.UFOPosition = this.transform.position;
        }
        // for any collisions include the bullet:
        Destroy(this.gameObject);
        UFOController.isFlying = false;
    }
}
