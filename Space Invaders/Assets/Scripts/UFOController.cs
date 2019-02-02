using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public GameObject UFO;
    public static int direction = 1;
    public static bool isFlying = false;

    void Update()
    {
        int num = Random.Range(0, 600);  // sometimes a lot sometime nothing??
        if (num == 0 && !isFlying)
        {
            num = Random.Range(0, 2);
            if (num == 0)
                direction = -1;
            else direction = 1;
            Instantiate(UFO, new Vector3(-14.5f * direction, 7.5f, 0), Quaternion.identity);
            isFlying = true;
        }
    }
    
}