using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    //Create a custom enumrator for our a scene
    public enum Scenes
    {
        bootUp,//0
        title,//1
        waveOne,//2
        waveTwo,//3
        waveThree,//4
        waveBoss,//5
        gameOver//6
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
