using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class printred : MonoBehaviour
{
    public static string redstr;
    /*public static string rmatc;
    public static string vicr;
    public static string lostr;*/

    public static int rmatc = 0;
    public static int vicr = 0;
    public static int lostr = 0;

    public Text red;
    public Text rmatches;
    public Text rwins;
    public Text rloss;
    void Start()
    {
        rmatc = Battlesystem.battlecount;
        vicr = Battlesystem.rwins;
        lostr = Battlesystem.rloss;
        //bs = GameObject.FindGameObjectWithTag("BATTLEMECH").GetComponent<Battlesystem>();
        red.text = redstr;
        rmatches.text = rmatc.ToString();
        rwins.text = vicr.ToString();
        rloss.text = lostr.ToString();
    }
}
