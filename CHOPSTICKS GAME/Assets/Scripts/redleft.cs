using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redleft : MonoBehaviour
{
    public Sprite redleft0;
    public Sprite redleft1;
    public Sprite redleft2;
    public Sprite redleft3;
    public Sprite redleft4;
    public Sprite redleft5;
    public void redlspritechange(int a)
    {
        if (a == 1)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft1;
        if (a == 2)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft2;
        if (a == 3)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft3;
        if (a == 4)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft4;
        if (a >= 5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft5;
            a = 0;
        }
        if (a == 0)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = redleft0;
    }
}
