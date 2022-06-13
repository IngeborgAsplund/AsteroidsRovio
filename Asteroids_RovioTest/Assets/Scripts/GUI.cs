using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUI : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text livesText;
    [SerializeField]
    GameObject gameoverText;
    [SerializeField]
    GameObject startButton;
    [SerializeField]
    GameObject exitButton;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.GameGUI = this;
    }
    public void Exitapplication() 
    {
        Application.Quit();
    }
    public void CallStart() 
    {
        HideGameOver();
        GameManager.Instance.StartGame();
    }
    public void UpdateLivesLabel(int lives) 
    {
        livesText.text = lives.ToString();
    }
    public void UpdateScoreLabel(int score) 
    {
        scoreText.text = score.ToString();
    }
    public void ShowGameOver() 
    {
        gameoverText.SetActive(true);
        startButton.SetActive(true);
        exitButton.SetActive(true);
    }
    public void HideGameOver() 
    {
        gameoverText.SetActive(false);
        startButton.SetActive(false);
        exitButton.SetActive(false);
    }

}
