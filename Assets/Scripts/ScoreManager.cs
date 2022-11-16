using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Values to track the player score
    static int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        private set { playerScore = value; }
    }

    //Simple reset function
    public void Reset()
    {
        playerScore = 0;
    }

    //Update player score
    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
    }
}
