using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LevelFinisher();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
