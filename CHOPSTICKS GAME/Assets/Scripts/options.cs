using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public Button attack;
    public Button share;
    public Button cancel;
    public Button done;
    public Button up1;
    public Button down1;
    public Button up2;
    public Button down2;

    public void Start()
    {
        up1.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
    }
    public void Attack()
    {
        attack.gameObject.SetActive(false);
        share.gameObject.SetActive(false);
        up1.gameObject.SetActive(true);
        down1.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
        //done.gameObject.SetActive(true);
    }

    public void Share()
    {
        share.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        up1.gameObject.SetActive(true);
        down1.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
        //done.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        Battlesystem.currchoice = 0;
        Battlesystem.enemychoice = 0;
        cancel.gameObject.SetActive(false);
        share.gameObject.SetActive(true);
        attack.gameObject.SetActive(true);
        down2.gameObject.SetActive(false);
        up1.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        //done.gameObject.SetActive(false);

    }

    public void Done()
    {
        done.gameObject.SetActive(false);
        share.gameObject.SetActive(true);
        attack.gameObject.SetActive(true);
        down2.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
    }

    public void Up1()
    {
        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        up2.gameObject.SetActive(true);
        down2.gameObject.SetActive(true);
    }

    public void Down1()
    {
        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        up2.gameObject.SetActive(true);
        down2.gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
