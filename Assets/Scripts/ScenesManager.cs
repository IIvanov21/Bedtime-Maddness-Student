using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //Create custom names for our scenes
    public enum Scenes
    {
        bootUp,
        title,
        waveOne,
        waveTwo,
        waveThree,
        waveBoss,
        gameOver
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        SceneManager.LoadScene((int)Scenes.gameOver);
        
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("testScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scenes.title);
    }

    public void ExitGame()
    {
        //This doesn't work for the editor. Only works in actual build application.
        Application.Quit();
    }


}
