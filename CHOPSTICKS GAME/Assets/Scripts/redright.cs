using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redright : MonoBehaviour
{
    public Sprite redright0;
    public Sprite redright1;
    public Sprite redright2;
    public Sprite redright3;
    public Sprite redright4;
    public Sprite redright5;

    public void redrspritechange(int b)
    {
        if (b == 1)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright1;
            if (b == 2)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright2;
        if (b == 3)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright3;
        if (b == 4)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright4;
        if (b >= 5)
        {
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright5;
            b = 0;
        }
        if (b == 0)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<SpriteRenderer>().sprite = redright0;
    }
}
