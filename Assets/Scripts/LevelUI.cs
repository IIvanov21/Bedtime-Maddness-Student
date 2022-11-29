using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    //Level UI variables
    [SerializeField]
    GameObject pauseMenu;

    bool isPaused = false;

    [SerializeField]
    Slider playerSuffocationBar;

    [SerializeField]
    TMP_Text scoreText;

    //Create function delegates for our LifeSystemTracker and ScoreSystem
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;

    public delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;

    private void Start()
    {
        onLifeUpdate = LifeSystemTracker;
        onScoreUpdate = ScoreSystem;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }


    public void LifeSystemTracker()
    {
        if (GameManager.playerHealth < 100) 
        {
            Debug.Log("Player's current suffocation level is: " + GameManager.playerHealth + "%");
            playerSuffocationBar.value = GameManager.playerHealth;
        }
        else
        {//If we die load the game over scene
            Debug.Log("Player's current suffocation level is: " + GameManager.playerHealth + "% We are dead!");
            playerSuffocationBar.value = GameManager.playerHealth;
            GetComponent<ScenesManager>().GameOver();

        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;//Simple switch statement between true and false     

        pauseMenu.SetActive(isPaused);//Enable/Disable the Pause Menu

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ScoreSystem()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
    }
}
