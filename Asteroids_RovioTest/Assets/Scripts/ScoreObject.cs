using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    private int highscore = 0;
    void Start()
    {
        GameManager.Instance.Score = this;
    }
    public void AddNewScore(int newScore) 
    {
        highscore += newScore;
        GameManager.Instance.GameGUI.UpdateScoreLabel(highscore);
    }
    public void ClearScore() 
    {
        highscore = 0;
        GameManager.Instance.GameGUI.UpdateScoreLabel(highscore);
    }
}
