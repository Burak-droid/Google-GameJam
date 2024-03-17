using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("CutScene");
    }

    public void Option()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }
    public void mainmenu()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
