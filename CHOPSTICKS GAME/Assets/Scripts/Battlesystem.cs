using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public enum BattleState { START, PLAYER1, PLAYER2, WON};
public class Battlesystem : MonoBehaviour
{
    gamecode g;
    public static BattleState state;
    public Text DialogueText;
    public Text GetreadyText;
    public Text FightText;
    public Text ChoiceText;
    public Text Player;
    public Text Wins;
    public static string rname = "1";
    public static string bname = "2";
    public static int currchoice = 0;
    public static int enemychoice = 0;
    bool gamestatus = false;

    public AudioSource FIGHT;
    public AudioSource KO;

    public Animator transition;
    public float transitionTime = 1f;

    public int won = 0;

    public static int battlecount = 0;
    public static int rwins = 0;
    public static int rloss = 0;
    public static int bwins = 0;
    public static int bloss = 0;

    public Button attack;
    public Button share;
    public Button sharedummy;
    public Button cancel;
    public Button done;
    public Button up1;
    public Button down1;
    public Button up2;
    public Button down2;
    public Button rshareup;
    public Button rsharedown;
    public Button bshareup;
    public Button bsharedown;

    // Start is called before the first frame update
    void Start()
    {
        battlecount = printname.bmatc;
        battlecount = printred.rmatc;
        battlecount += 1;
        up1.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        rshareup.gameObject.SetActive(false);
        bshareup.gameObject.SetActive(false);
        rsharedown.gameObject.SetActive(false);
        bsharedown.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        share.gameObject.SetActive(false);
        sharedummy.gameObject.SetActive(false);

        g = GameObject.FindGameObjectWithTag("GameCode").GetComponent<gamecode>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GetreadyText.text = "GET READY";
        yield return new WaitForSeconds(2f);
        FIGHT.Play();
        GetreadyText.text = "3";
        yield return new WaitForSeconds(1f);
        GetreadyText.text = "2";
        yield return new WaitForSeconds(1f);
        GetreadyText.text = "1";
        yield return new WaitForSeconds(1f);
        GetreadyText.text = " ";
        FightText.text = "FIGHT!";
        yield return new WaitForSeconds(1f);
        FightText.text = " ";
        attack.gameObject.SetActive(true);
        sharedummy.gameObject.SetActive(true);
        state = BattleState.PLAYER1;
        redturn();
    }

    void redturn()
    {
        up2.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        if(g.a == 1 && g.b == 1)
        {
            sharedummy.gameObject.SetActive(true);
            share.gameObject.SetActive(false);
        }
        else
        {
            sharedummy.gameObject.SetActive(false);
            share.gameObject.SetActive(true);
        }
        DialogueText.text = rname + "'s turn";
        ChoiceText.text = "Choose your action";
    }

    void blueturn()
    {

        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        if (g.c == 1 && g.d == 1)
        {
            sharedummy.gameObject.SetActive(true);
            share.gameObject.SetActive(false);
        }
        else
        {
            sharedummy.gameObject.SetActive(false);
            share.gameObject.SetActive(true);
        }
        DialogueText.text = bname + "'s turn";
        ChoiceText.text = "Choose your action";
    }

    /*public void OnAttackButton()
    {
        if (state != BattleState.PLAYER1)
            return; 
    }*/

    public void redleft()
    {
        if (state == BattleState.PLAYER1)
            currchoice = 1;
        else if (state == BattleState.PLAYER2)
            enemychoice = 1;
        if (currchoice != 0 && enemychoice != 0)
        {
            gamestatus = g.Attack(currchoice, enemychoice);
            Debug.Log("gamestatus " + gamestatus);
            hidebuttons();
            StartCoroutine(PlayerAttack());
        }
    }
    public void redright()
    {
        if (state == BattleState.PLAYER1)
            currchoice = 2;
        else if (state == BattleState.PLAYER2)
            enemychoice = 2;
        if (currchoice != 0 && enemychoice != 0)
        {
            gamestatus = g.Attack(currchoice, enemychoice);
            Debug.Log("gamestatus " + gamestatus);
            hidebuttons();
            StartCoroutine(PlayerAttack());
        }
    }
    public void blueright()
    {
        if (state == BattleState.PLAYER2)
            currchoice = 3;
        else if (state == BattleState.PLAYER1)
            enemychoice = 3;
        if (currchoice != 0 && enemychoice != 0)
        {
            gamestatus = g.Attack(currchoice, enemychoice);
            hidebuttons();
            //samhidebuttons();
            StartCoroutine(PlayerAttack());
        }
    }
    public void blueleft()
    {
        if (state == BattleState.PLAYER2)
            currchoice = 4;
        else if (state == BattleState.PLAYER1)
            enemychoice = 4;
        if (currchoice != 0 && enemychoice != 0)
        {
            gamestatus = g.Attack(currchoice, enemychoice);
            hidebuttons();
            //samhidebuttons();
            StartCoroutine(PlayerAttack());
        }
    }

    public void blueup()
    { 
        cancel.gameObject.SetActive(false);
        done.gameObject.SetActive(true);
        g.bushare();
    }

    public void bluedown()
    {
        cancel.gameObject.SetActive(false);
        done.gameObject.SetActive(true);
        g.bdshare();
    }

    public void redup()
    {
        cancel.gameObject.SetActive(false);
        done.gameObject.SetActive(true);
        g.rushare();
    }

    public void reddown()
    {
        cancel.gameObject.SetActive(false);
        done.gameObject.SetActive(true);
        g.rdshare();
    }

    IEnumerator PlayerAttack()
    {
        if (state == BattleState.PLAYER1)
        {
            if (gamestatus)
            {
                state = BattleState.WON;
                won = 1;
                StartCoroutine(battleend());
            }
            else
            {
                state = BattleState.PLAYER2;
                blueturn();
            }
        }
        else if(state == BattleState.PLAYER2)
        {
            if (gamestatus)
            {
                state = BattleState.WON;
                won = 2;
                StartCoroutine(battleend());
            }
            else
            {
                state = BattleState.PLAYER1;
                redturn();
            }
        }
        yield return new WaitForSeconds(2f);
    }
    public void Attack()
    {
        if (state == BattleState.PLAYER1)
        {
            ChoiceText.text = "Pick your hand";
            attack.gameObject.SetActive(false);
            share.gameObject.SetActive(false);
            sharedummy.gameObject.SetActive(false);
            if (g.a == 0)
                down1.gameObject.SetActive(true);
            if (g.b == 0)
                up1.gameObject.SetActive(true);
            if(g.a != 0 && g.b != 0)
            {
                up1.gameObject.SetActive(true);
                down1.gameObject.SetActive(true);
            }
            cancel.gameObject.SetActive(true);
        }
        else if (state == BattleState.PLAYER2)
        { 
            ChoiceText.text = "Pick your hand";
            attack.gameObject.SetActive(false);
            share.gameObject.SetActive(false);
            sharedummy.gameObject .SetActive(false);
            if (g.c == 0)
                down2.gameObject.SetActive(true);
            if (g.d == 0)
                up2.gameObject.SetActive(true);
            if(g.c != 0 && g.d != 0)
            {
                up2.gameObject.SetActive(true);
                down2.gameObject.SetActive(true);
            }
            cancel.gameObject.SetActive(true);
        }
    }

    public void Share()
    {
        ChoiceText.text = "Shift fingers";
        if (state == BattleState.PLAYER1)
        {
            share.gameObject.SetActive(false);
            attack.gameObject.SetActive(false);
            rshareup.gameObject.SetActive(true);
            rsharedown.gameObject.SetActive(true);
            cancel.gameObject.SetActive(true);
        }
        else if (state == BattleState.PLAYER2)
        {
            share.gameObject.SetActive(false);
            attack.gameObject.SetActive(false);
            bshareup.gameObject.SetActive(true);
            bsharedown.gameObject.SetActive(true);
            cancel.gameObject.SetActive(true);
        }
    }

    public void Sharedummy()
    {
        ChoiceText.text = "You cannot share right now";
    }

    public void Cancel()
    {
        ChoiceText.text = "Choose your action";
        Battlesystem.currchoice = 0;
        Battlesystem.enemychoice = 0;
        cancel.gameObject.SetActive(false);
        share.gameObject.SetActive(true);
        attack.gameObject.SetActive(true);
        down2.gameObject.SetActive(false);
        up1.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        rshareup.gameObject.SetActive(false);
        bshareup.gameObject.SetActive(false);
        rsharedown.gameObject.SetActive(false);
        bsharedown.gameObject.SetActive(false);
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
        rshareup.gameObject.SetActive(false);
        bshareup.gameObject.SetActive(false);
        rsharedown.gameObject.SetActive(false);
        bsharedown.gameObject.SetActive(false);
        StartCoroutine(PlayerAttack());
    }

    public void Up1()
    {
        ChoiceText.text = "Choose hand to attack";
        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        if(state == BattleState.PLAYER1)
        {
            if (g.c == 0)
                down2.gameObject.SetActive(true);
            if (g.d == 0)
                up2.gameObject.SetActive(true);
            if (g.c != 0 && g.d != 0)
            {
                up2.gameObject.SetActive(true);
                down2.gameObject.SetActive(true);
            }
        }
        else if(state == BattleState.PLAYER2) 
        {
            if (g.a == 0)
                down1.gameObject.SetActive(true);
            if (g.b == 0)
                up1.gameObject.SetActive(true);
            if (g.a != 0 && g.b != 0)
            {
                up1.gameObject.SetActive(true);
                down1.gameObject.SetActive(true);
            }
        }
        //checkhide();
    }

    public void Down1()
    {
        ChoiceText.text = "Choose hand to attack";
        up1.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        if (state == BattleState.PLAYER1)
        {
            if (g.c == 0)
                down2.gameObject.SetActive(true);
            if (g.d == 0)
                up2.gameObject.SetActive(true);
            if (g.c != 0 && g.d != 0)
            {
                up2.gameObject.SetActive(true);
                down2.gameObject.SetActive(true);
            }
        }
        else if (state == BattleState.PLAYER2)
        {
            if (g.a == 0)
                down1.gameObject.SetActive(true);
            if (g.b == 0)
                up1.gameObject.SetActive(true);
            if (g.a != 0 && g.b != 0)
            {
                up1.gameObject.SetActive(true);
                down1.gameObject.SetActive(true);
            }
        }
        //checkhide();
    }

    public void Up2()
    {
        ChoiceText.text = "Choose hand to attack";
        up2.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        if (state == BattleState.PLAYER1)
        {
            if (g.c == 0)
                down2.gameObject.SetActive(true);
            if (g.d == 0)
                up2.gameObject.SetActive(true);
            if (g.c != 0 && g.d != 0)
            {
                up2.gameObject.SetActive(true);
                down2.gameObject.SetActive(true);
            }
        }
        else if (state == BattleState.PLAYER2)
        {
            if (g.a == 0)
                down1.gameObject.SetActive(true);
            if (g.b == 0)
                up1.gameObject.SetActive(true);
            if (g.a != 0 && g.b != 0)
            {
                up1.gameObject.SetActive(true);
                down1.gameObject.SetActive(true);
            }
        }
        //checkhide();
    }

    public void Down2()
    {
        ChoiceText.text = "Choose hand to attack";
        up2.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        if (state == BattleState.PLAYER1)
        {
            if (g.c == 0)
                down2.gameObject.SetActive(true);
            if (g.d == 0)
                up2.gameObject.SetActive(true);
            if (g.c != 0 && g.d != 0)
            {
                up2.gameObject.SetActive(true);
                down2.gameObject.SetActive(true);
            }
        }
        else if (state == BattleState.PLAYER2)
        {
            if (g.a == 0)
                down1.gameObject.SetActive(true);
            if (g.b == 0)
                up1.gameObject.SetActive(true);
            if (g.a != 0 && g.b != 0)
            {
                up1.gameObject.SetActive(true);
                down1.gameObject.SetActive(true);
            }
        }
        //checkhide();
    }

    void hidebuttons()
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
        rshareup.gameObject.SetActive(false);
        bshareup.gameObject.SetActive(false);
        rsharedown.gameObject.SetActive(false);
        bsharedown.gameObject.SetActive(false);
        //done.gameObject.SetActive(false);
    }

    /*void closecancel()
    {
        cancel.gameObject.SetActive(false);
    }

    void enabledone()
    {
        done.gameObject.SetActive(true);
    }*/

    IEnumerator battleend()
    {
        up1.gameObject.SetActive(false);
        up2.gameObject.SetActive(false);
        down1.gameObject.SetActive(false);
        down2.gameObject.SetActive(false);
        rshareup.gameObject.SetActive(false);
        bshareup.gameObject.SetActive(false);
        rsharedown.gameObject.SetActive(false);
        bsharedown.gameObject.SetActive(false);
        done.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        share.gameObject.SetActive(false);

        if(won == 1)
        {
            rwins = printred.vicr;
            rloss = printred.lostr;
            rwins += 1;
            bloss = printname.lostb;
            bwins = printname.vicb;
            bloss += 1;
            DialogueText.text = "";
            ChoiceText.text = "";
            FightText.text = "K";
            KO.Play();
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.";
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.O";
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.O!";
            yield return new WaitForSeconds(2f);
            FightText.text = "";
            Player.text = rname;
            Wins.text = "WINS!";
            yield return new WaitForSeconds(1f);
            LoadNextLevel(6);
        }
        else
        {
            rwins = printred.vicr;
            rloss = printred.lostr;
            rloss += 1;
            bloss = printname.lostb;
            bwins = printname.vicb;
            bwins += 1;
            DialogueText.text = "";
            ChoiceText.text = "";
            FightText.text = "K";
            KO.Play();
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.";
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.O";
            yield return new WaitForSeconds(0.5f);
            FightText.text = "K.O!";
            yield return new WaitForSeconds(2f);
            FightText.text = "";
            Player.text = bname;
            Wins.text = "WINS!";
            yield return new WaitForSeconds(1f);
            LoadNextLevel(7);
        }
    }

    void samhidebuttons()
    {
        share.gameObject.SetActive(true);
        attack.gameObject.SetActive(true);
    }

    void checkhide()
    {
        if ((share.gameObject == true) && (attack.gameObject == true))
        {
            Battlesystem.currchoice = 0;
            Battlesystem.enemychoice = 0;
            cancel.gameObject.SetActive(false);
            down2.gameObject.SetActive(false);
            up1.gameObject.SetActive(false);
            up2.gameObject.SetActive(false);
            down1.gameObject.SetActive(false);
            rshareup.gameObject.SetActive(false);
            bshareup.gameObject.SetActive(false);
            rsharedown.gameObject.SetActive(false);
            bsharedown.gameObject.SetActive(false);
            //done.gameObject.SetActive(false);
        }
    }

    public void LoadNextLevel(int n)
    {
        StartCoroutine(LoadLevel(n));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}


/*
do
{
    if (currchoice != 0 && enemychoice != 0)
    {
        bool gamestatus = g.Attack(currchoice, enemychoice);
    }
} while (currchoice == 0 && enemychoice == 0) ;
*/