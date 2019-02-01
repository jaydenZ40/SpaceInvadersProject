using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float bulletSpeed = 10f;
    void Update()
    {
        this.transform.Translate(new Vector3(0, -1 * Time.deltaTime * bulletSpeed));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LowerBorder"))
        {
            Destroy(this.gameObject);
        }
    }
}
