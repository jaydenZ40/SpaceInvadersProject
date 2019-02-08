using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float bulletSpeed = 10f;
    void Update()
    {
        this.transform.Translate(new Vector3(0, -1 * Time.deltaTime * bulletSpeed));
        Physics2D.IgnoreLayerCollision(9, 10);  // ignore the collision between enemies and enemies's bullets
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LowerBorder"))
        {
            Destroy(this.gameObject);
        }
    }
}
