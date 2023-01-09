using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class SceneSwitcher : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void playGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }
    public void leave()
    {
        Application.Quit();
    }
    IEnumerator LoadLevel(int levelIndex)
    { 
    transition.SetTrigger("Start");
    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(levelIndex);
    }

}

