using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject LoadingInterface;
    public Image LoadingProgressBar;
    List<AsyncOperation> ScenesToLoad = new List<AsyncOperation>();

    public void LoadLevel(string SceneName)
    {
        HideMenu();
        ShowLoadingScreen();
        ScenesToLoad.Add(SceneManager.LoadSceneAsync(SceneName));        
        StartCoroutine(LoadingScreen());
    }

    public void HideMenu()
    {
        Menu.SetActive(false);
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }

    public void ShowLoadingScreen()
    {
        LoadingInterface.SetActive(true);
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for (int i = 0; i < ScenesToLoad.Count; ++i)
        {
            while (!ScenesToLoad[i].isDone)
            {
                totalProgress += ScenesToLoad[i].progress;
                LoadingProgressBar.fillAmount = totalProgress / ScenesToLoad.Count;
                yield return null;
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
