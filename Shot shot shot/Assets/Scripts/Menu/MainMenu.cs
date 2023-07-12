using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Class that holds the methods accesible from the main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject LoadingInterface;
    [SerializeField] public Image LoadingProgressBar;
    private List<AsyncOperation> ScenesToLoad = new List<AsyncOperation>();

    /// <summary>
    /// takes on a string and loads and scene with that name
    /// </summary>
    /// <param name="SceneName"></param>
    public void LoadLevel(string SceneName)
    {
        HideMenu();
        ShowLoadingScreen();
        ScenesToLoad.Add(SceneManager.LoadSceneAsync(SceneName));        
        StartCoroutine(LoadingScreen());
    }

    /// <summary>
    /// Hides the canvas object
    /// </summary>
    public void HideMenu()
    {
        Menu.SetActive(false);
    }

    /// <summary>
    /// Activates the canvas object
    /// </summary>
    public void ShowMenu()
    {
        Menu.SetActive(true);
    }

    /// <summary>
    /// Activates the loading interface
    /// </summary>
    public void ShowLoadingScreen()
    {
        LoadingInterface.SetActive(true);
    }

    /// <summary>
    /// Takes an image and slowly fills it up
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Closes game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
