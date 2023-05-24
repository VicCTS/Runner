using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    public bool isPlaying = false;
    Scene scene;


    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SoundManager.Instance.SeleccionAudio(0);
        SceneManager.LoadScene(2);
    }

    public void LevelFinisher()
    {
        scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 3)
        {
            Global.nivelMaximo = 0;
            PlayerPrefs.SetInt("LevelMax",Global.nivelMaximo);
            SoundManager.Instance.SeleccionAudio(0);
            SceneManager.LoadScene(2);
        }
        else
        {
            Global.nivelMaximo ++;
        
            SceneManager.LoadScene(scene.buildIndex + 1);
            SFXManager.Instance.CuentaRegresivaSound();
            SoundManager.Instance.SeleccionAudio(1);
            //uwu
            PlayerPrefs.SetInt("LevelMax",Global.nivelMaximo);
        }
        
    }

    public void Choque()
    {
        Global.vidas--;
        SFXManager.Instance.DeathSound();
        
        if(Global.vidas == 0)
        {
            InGameMenuManager.Instance.DeathMenu();
            Debug.Log("Dead");
            isPlaying = false;
            
        }   
    }

    public void AddCoins()
    {
        Global.numberCoins += 1;
        SFXManager.Instance.CoinSFX();
    }

}
