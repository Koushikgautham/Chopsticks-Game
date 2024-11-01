using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redname : MonoBehaviour
{
    public GameObject InputField;
    public string Rname;
    public void StoreNameRed()
    {
        Rname = InputField.GetComponent<Text>().text;
        printred.redstr = Rname;
        Battlesystem.rname = Rname;
    }
}
