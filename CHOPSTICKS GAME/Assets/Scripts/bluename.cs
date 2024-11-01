using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluename : MonoBehaviour
{
    public GameObject InputField;
    public string Bname;
    public void StoreNameBlue()
    {
        Bname = InputField.GetComponent<Text>().text;
        printname.bluestr = Bname;
        Battlesystem.bname = Bname;
    }
}
