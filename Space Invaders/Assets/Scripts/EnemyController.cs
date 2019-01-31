using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int points = 0;
    public static bool isLowest = false;
    public static bool isChosenToFire = false;
    public GameObject EnemyBullet;

    void Update()
    {
        if (isChosenToFire)
        {
            Instantiate(EnemyBullet, this.transform.position + new Vector3(0, -1, 0), new Quaternion(0, 0, 0, 0));
            isChosenToFire = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayerController.score += points;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            PlayerController.isFiring = false;
            
        }
        if (other.gameObject.CompareTag("RightBorder"))
        {
            EnemyUnionMovement.moveDirection = -1;
            EnemyUnionMovement.moveDown = true;
        }
        if (other.gameObject.CompareTag("LeftBorder"))
        {
            EnemyUnionMovement.moveDirection = 1;
            EnemyUnionMovement.moveDown = true;
        }
        if (other.gameObject.CompareTag("LowerBorder"))
        {
            PlayerController.isGameOver = true;
        }
    }
}
