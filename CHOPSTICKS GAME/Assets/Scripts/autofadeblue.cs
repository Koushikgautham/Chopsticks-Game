using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class autofadeblue : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public float transitionTime1 = 5f;

    void Awake()
    {
        Invoke("LoadNextLevel", transitionTime1);
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(5));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}