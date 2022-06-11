using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private GameBoard gameBoard;
    private GUI gameGUI;
    private ScoreObject score;
    private bool gameOver;
    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = new GameManager();
        }
        else
        {
            Instance = this;
        }
    }
    public GameBoard Board 
    {
        get { return gameBoard; }
        set { gameBoard = value; }
    }
    public GUI GameGUI 
    {
        get { return gameGUI; }
        set { gameGUI = value; }
    }
    public ScoreObject Score 
    {
        get { return score; }
        set { score = value; }
    }
    public bool GameOver 
    {
        get { return gameOver; }
    }
    public void StartGame() 
    {
        gameOver = false;
        Score.ClearScore();
        Debug.Log("started");
        Board.SetStartingLives();
        Board.SpawnPlayer();
        Board.AsteroidsInGame.Clear();
        Board.SpawnAsteroids();
    }
    public void EndGame() 
    {
        gameOver = true;
        GameGUI.ShowGameOver();
    }
}
