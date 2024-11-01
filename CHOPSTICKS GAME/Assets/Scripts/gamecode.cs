using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecode : MonoBehaviour
{
    public Text Error;

    public int a = 1;
    public int rr = 1;
    public int b = 1;
    public int rl = 2;
    public int c = 1;
    public int br = 3;
    public int d = 1;
    public int bl = 4;

    public Sprite redleft0;
    public Sprite redleft1;
    public Sprite redleft2;
    public Sprite redleft3;
    public Sprite redleft4;
    public Sprite redleft5;
    public Sprite redright0;
    public Sprite redright1;
    public Sprite redright2;
    public Sprite redright3;
    public Sprite redright4;
    public Sprite redright5;
    
    public Sprite blueleft0;
    public Sprite blueleft1;
    public Sprite blueleft2;
    public Sprite blueleft3;
    public Sprite blueleft4;
    public Sprite blueleft5;
    public Sprite blueright0;
    public Sprite blueright1;
    public Sprite blueright2;
    public Sprite blueright3;
    public Sprite blueright4;
    public Sprite blueright5;

    public AudioSource punch1;
    public AudioSource punch2;
    public AudioSource swoosh;
    
    public bool Attack(int m, int n)
    {
        if (Battlesystem.state == BattleState.PLAYER1)
        {
            punch1.Play();
        }
        else
        {
            punch2.Play();
        }
        Debug.Log("The code runs here");
        if (m == rr && n == br)
        {
            c += a;
        }
        else if (m == rr && n == bl)
        {
            d += a;
        }
        else if (m == rl && n == br)
        {
            c += b;
        }
        else if (m == rl && n == bl)
        {
            d += b;
        }
        else if (m == br && n == rr)
        {
            a += c;
        }
        else if (m == br && n == rl)
        {
            b += c;
        }
        else if (m == bl && n == rr)
        {
            a += d;
        }
        else
        {
            b += d;
        }

        spritechanger();

        if (a >= 5)
            a = 0;
        if (b >= 5)
            b = 0;
        if (c >= 5)
            c = 0;
        if (d >= 5)
            d = 0;


        if (a == 0 && b == 0)
        {
            return true;
        }
        if(c == 0 && d == 0)
        {
            return true;
        }
        else
            return false;
    }

    public void rushare()
    {
        swoosh.Play();
        if (b > 1)
        {
            a += 1;
            b -= 1;
            spritechanger();
        }
        else if (b == 1)
        {
            Error.text = "Cannot kill hand!";
        }
        else
        {
            Error.text = "Hand is Dead!";
        }
    }

    public void rdshare()
    {
        swoosh.Play();
        if (a > 1)
        {
            b += 1;
            a -= 1;
            spritechanger();
        }
        else if(a == 1)
        {
            Error.text = "Cannot kill hand!";
        }
        else
        {
            Error.text = "Hand is Dead!";
        }
    }

    public void bushare()
    {
        swoosh.Play();
        if (d > 1)
        {
            c += 1;
            d -= 1;
            spritechanger();
        }
        else if (d == 1)
        {
            Error.text = "Cannot kill hand!";
        }
        else
        {
            Error.text = "Hand is Dead!";
        }
    }

    public void bdshare()
    {
        swoosh.Play();
        if (c > 1)
        {
            d += 1;
            c -= 1;
            spritechanger();
        }
        else if (c == 1)
        {
            Error.text = "Cannot kill hand!";
        }
        else
        {
            Error.text = "Hand is Dead!";
        }
    }

    void spritechanger()
    {
        if (a == 1)
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft1;
        if (a == 2)
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft2;
        if (a == 3)
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft3;
        if (a == 4)
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft4;
        if (a >= 5)
        {
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft5;
            a = 0;
        }
        if (a == 0)
            GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<Image>().sprite = redleft0;



        if (b == 1)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright1;
        if (b == 2)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright2;
        if (b == 3)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright3;
        if (b == 4)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright4;
        if (b >= 5)
        {
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright5;
            b = 0;
        }
        if (b == 0)
            GameObject.FindGameObjectWithTag("REDRIGHT").GetComponent<Image>().sprite = redright0;



        if (c == 1)
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright1;
        if (c == 2)
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright2;
        if (c == 3)
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright3;
        if (c == 4)
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright4;
        if (c >= 5)
        {
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright5;
            c = 0;
        }
        if (c == 0)
            GameObject.FindGameObjectWithTag("BLUERIGHT").GetComponent<Image>().sprite = blueright0;



        if (d == 1)
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft1;
        if (d == 2)
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft2;
        if (d == 3)
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft3;
        if (d == 4)
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft4;
        if (d >= 5)
        {
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft5;
            d = 0;
        }
        if (d == 0)
            GameObject.FindGameObjectWithTag("BLUELEFT").GetComponent<Image>().sprite = blueleft0;
    }
}
