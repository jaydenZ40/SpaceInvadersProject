using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int row = 1; // change others in component window
    public int column = 0;
    private int points = 40;
    public GameObject EnemyBullet;

    void Awake()
    {
        if (row == 2 || row == 3)
            points = 20;
        else if (row == 4 || row == 5)
            points = 10;

        string str = this.transform.parent.name;
        column = str[str.Length - 1] - '0';
        if (str[str.Length - 1] == '0')
            column = 10;
        else if (str[str.Length - 1] == '1')
            if (str[str.Length - 2] == '1')
                column = 11;
        // get the column by the last character of name. If last character is 0 or 1, check the previous character.
    }
    public void isChosenToFire()
    {
        Instantiate(EnemyBullet, this.transform.position + new Vector3(0, -1, 0), new Quaternion(0, 0, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayerController.score += points;
            Destroy(other.gameObject);
            if (this.transform.parent.childCount == 1)
            {
                Destroy(this.transform.parent.gameObject);
            }
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
