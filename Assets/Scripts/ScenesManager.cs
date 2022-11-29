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
        SceneManager.LoadScene((int)Scenes.waveOne);
        GameManager.currentScene = SceneManager.GetActiveScene().buildIndex + 1;
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

    public void NextLevel()
    {
        switch(GameManager.currentScene)
        {
            default:
                {
                    Debug.Log("Changing scene to: " + GameManager.currentScene);
                    break;
                }
            case 2: case 3: case 4: case 5:
                {
                    SceneManager.LoadScene(GameManager.currentScene+1);
                    GameManager.currentScene++;
                    break;
                }
        }
    }

}
