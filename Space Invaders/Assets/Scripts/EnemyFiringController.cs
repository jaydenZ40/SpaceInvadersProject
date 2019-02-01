using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringController : MonoBehaviour
{
    private float timer = 0;
    private float nextFire = 0;

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
        int col, row;
        int curColumnNumber = transform.childCount;
        col = Random.Range(0, curColumnNumber); // choose a random column to fire
        int curRowNumber = transform.GetChild(col).transform.childCount;
        row = curRowNumber - 1; //  The enemy in last row will be chosen to fire

        transform.GetChild(col).GetChild(row).GetComponent<EnemyController>().Invoke("isChosenToFire", 0f);
    }
}
