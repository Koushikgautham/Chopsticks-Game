using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public AudioSource buttonsound;
    public void PlayGame ()
    {
        buttonsound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame ()
    {
        buttonsound.Play();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
