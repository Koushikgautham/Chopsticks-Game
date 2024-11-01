using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public Sprite next;

    void newspritechange()
    {
        GameObject.FindGameObjectWithTag("REDLEFT").GetComponent<SpriteRenderer>().sprite = next;
    }
    
}
