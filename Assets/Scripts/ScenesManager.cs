using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    //Create a custom enumrator for our a scene
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
 
}
