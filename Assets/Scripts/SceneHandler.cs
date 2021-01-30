using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{

    public GameObject loadingScreen;
    //public Slider slider;

    public void ReplayGame()
    {
        SceneManager.LoadScene("3D Run");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Tutorial");

        StartCoroutine(LoadGame("3D Run"));
    }

    IEnumerator LoadGame(string str)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(str);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            //slider.value = progress;

            yield return null;
        }
    }

    public void SelectPlayer()
    {
        SceneManager.LoadScene("Selection");
    }

    public void Cross()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
