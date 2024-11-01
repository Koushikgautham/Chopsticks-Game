using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public Animator transition;

    public AudioSource buttonsound;

    public float transitionTime = 1f;

    public void PlayAgain()
    {
        buttonsound.Play();
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(8));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitFull()
    {
        buttonsound.Play();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
