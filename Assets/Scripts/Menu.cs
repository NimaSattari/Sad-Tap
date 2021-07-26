using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject infoPanel;

    public void LoadGameScene(string gameSceneName)
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowHideUI(GameObject uIToShowAndHide)
    {
        if (uIToShowAndHide.activeInHierarchy)
        {
            uIToShowAndHide.SetActive(false);
        }
        else
        {
            uIToShowAndHide.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
