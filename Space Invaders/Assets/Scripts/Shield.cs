using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitCount = 0;
    private SpriteRenderer mySprite;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        /*
        mySprite = this.gameObject.GetComponent<SpriteRenderer>();
        //sprites = new Sprite[4];
        sprites = Resources.LoadAll<Sprite>("../Art/ShieldBase");
        string spriteNameEnd = sprites[0].name.Substring(4);
        for (int i = 1; i < 4; i++)
        {
            //load sprites for this base piece
            Resources.Load<Sprite>("SBD" + i.ToString() + spriteNameEnd);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IveBeenHit()
    {
        hitCount++;
        string sname = mySprite.name;
        if (4 == hitCount)
        {
            GameObject myGO = this.gameObject;
            Destroy(myGO);
            return;
        }
        mySprite.sprite = sprites[hitCount * 10 + int.Parse(sname.Substring(5,1))];
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayerController.isFiring = false;
            IveBeenHit();
        }
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            IveBeenHit();
        }
        Destroy(other.gameObject);
    }
}
