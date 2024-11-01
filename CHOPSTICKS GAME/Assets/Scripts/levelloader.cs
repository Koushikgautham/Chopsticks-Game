using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public AudioSource buttonsound1;

    public Animator transistion;

    public float transitionTime = 1f;

    public void Playgame()
    {
        buttonsound1.Play();
        Loadnextlevel();
    }

    public void Loadnextlevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transistion.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
