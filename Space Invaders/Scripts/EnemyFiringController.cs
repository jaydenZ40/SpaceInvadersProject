using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiringController : MonoBehaviour
{
    private float timer = 0;
    private float nextFire = 0;
    private float fireInterval;

    void Update()
    {
        timer += Time.deltaTime;
        fireInterval = 10f - 5f * timer / 50f;
        if (timer >= nextFire)
        {
            randomFire();
            nextFire += Random.Range(0, fireInterval);
        }
    }
    void randomFire()
    {
        if (timer > 3)  // first 3 sec will not shoot to protect the player
        {
            int col, row;
            int curColumnNumber = transform.childCount;
            col = Random.Range(0, curColumnNumber); // choose a random column to fire
            int curRowNumber = transform.GetChild(col).transform.childCount;
            if (curRowNumber == 0)
                Destroy(transform.GetChild(col).gameObject);    // fix the bug: when the bullet hits two object, the parent will not be destoryed
            row = curRowNumber - 1; //  The enemy in last row will be chosen to fire

            transform.GetChild(col).GetChild(row).GetComponent<EnemyController>().Invoke("isChosenToFire", 0f);
        }
    }
}
