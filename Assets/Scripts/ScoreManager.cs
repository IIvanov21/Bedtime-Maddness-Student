using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
