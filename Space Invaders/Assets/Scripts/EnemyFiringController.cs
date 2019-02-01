using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringController : MonoBehaviour
{
    public static bool[][] aliveEnemies = new bool[5][];
    private float timer = 0;
    private float nextFire = 0;
    
    void Start()
    {
        for (int i = 0; i < 5; i++)
            aliveEnemies[i] = new bool[11];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 11; j++)
                aliveEnemies[i][j] = true;
        // a 5*11 boolean array represents the enemies, the value is true if the enemy is alive
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextFire)
        {
            randomFire();
            nextFire += Random.Range(0, 10);
        }
    }
    void randomFire()
    {
        int maxCol = 11;
        int row = -1, col = Random.Range(0, maxCol);
        while (row == -1 && maxCol > 0)
        {
            for (int i = 4; i >= 0; i--)
            {
                if (aliveEnemies[i][col])
                {
                    row = i;
                    break;
                }
            }
            maxCol--;
            col = Random.Range(0, maxCol);
        }
        print("col:" + col + ", row:" + row);
        // randomly pick a column to fire, check if there is an enemy in this colmun. If not, try another column.
        transform.GetChild(col).GetChild(row).GetComponent<EnemyController>().Invoke("isChosenToFire", 0);
    }
}
