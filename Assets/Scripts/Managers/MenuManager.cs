using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Titulo;
    public GameObject BotonesMenu;
    public GameObject OptionsMenu;
    public GameObject PlayMenu;

    public void OpenOptions()
    {
        Titulo.SetActive(false);
        BotonesMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void OpenLevels()
    {
        Titulo.SetActive(false);
        BotonesMenu.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void LoadScene()
    {
        Global.nivelMaximo = PlayerPrefs.GetInt("LevelMax");
        SceneManager.LoadScene(3);

        SFXManager.Instance.CuentaRegresivaSound();
        SoundManager.Instance.SeleccionAudio(1);

    }

    public void StartGame()
    {
        //GameManager.Instance.LevelFinisher();
        Global.nivelMaximo = 0;
        
        PlayerPrefs.SetInt("LevelMax",Global.nivelMaximo);
        SceneManager.LoadScene(3 + Global.nivelMaximo);

        SFXManager.Instance.CuentaRegresivaSound();
        SoundManager.Instance.SeleccionAudio(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
