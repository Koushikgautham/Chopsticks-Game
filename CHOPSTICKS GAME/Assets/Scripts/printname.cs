using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class printname : MonoBehaviour
{
    
    public static string bluestr;
    /*public static string bmatc;
    public static string vicb;
    public static string lostb;*/

    public static int bmatc = 0;
    public static int vicb = 0;
    public static int lostb = 0;

    public Text blue;
    public Text bmatches;
    public Text bwins;
    public Text bloss;
    void Start()
    {
        bmatc = Battlesystem.battlecount;
        vicb = Battlesystem.bwins;
        lostb = Battlesystem.bloss;
        //bs = GameObject.FindGameObjectWithTag("BATTLEMECH").GetComponent<Battlesystem>();
        blue.text = bluestr;
        bmatches.text = bmatc.ToString();
        bwins.text = vicb.ToString();
        bloss.text = lostb.ToString();
    }
}
