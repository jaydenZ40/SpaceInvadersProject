using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMovement : MonoBehaviour
{
    public float bulletSpeed = 10f;
    void Update()
    {
        this.transform.Translate(new Vector3(0, Time.deltaTime * bulletSpeed));
        if (this.transform.position.y > 10)
        {
            Destroy(this.gameObject);
            PlayerController.isFiring = false;
        }
    }
}
