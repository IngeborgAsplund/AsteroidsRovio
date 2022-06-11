using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private spaceship player;
    [SerializeField]
    int numberOfAsteroids = 10;
    [SerializeField]
    Asteroid asteroid;
    private List<Asteroid> asteroidsInGame;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timerValue;
    [SerializeField]
    private float rightBorder;
    [SerializeField]
    private float leftBorder;
    [SerializeField]
    private float upperEdge;
    [SerializeField]
    private float lowerEdge;
    [SerializeField]
    int Maxlives = 5;
    int currentLives = 0;
    private float timer;
    
    public float RightBorder 
    {
        get { return rightBorder; } 
    }
    public float LeftBorder
    {
        get { return leftBorder; }
    }
    public float UpperEdge
    {
        get { return rightBorder; }
    }
    public List<Asteroid> AsteroidsInGame 
    {
        get { return asteroidsInGame; }
    }
    private void Start()
    {
        GameManager.Instance.Board = this;
        asteroidsInGame = new List<Asteroid>();
        timer = timerValue;
    }
    private void Update()
    {
        if (timer > 0.0f) 
        {
            timer -= Time.deltaTime;
        }
    }
    public void SetStartingLives() 
    {
        currentLives = Maxlives;
    }

    public void DecreaseALife() 
    {
        currentLives--;
        GameManager.Instance.GameGUI.UpdateLivesLabel(currentLives);
        if (currentLives > 0) 
        {
            SpawnPlayer();
        }
        else
        {
            currentLives = 0;
            GameManager.Instance.EndGame();
        }
    }
      
    public void SpawnPlayer() 
    {
        Instantiate(player.gameObject, spawnPoint.transform.position,Quaternion.identity);
        GameManager.Instance.GameGUI.UpdateLivesLabel(currentLives);
    }

    public void ObjectCrossedBorder(GameObject actor) 
    {
        if (timer <= 0.0) 
        {
            if (actor.transform.position.x < leftBorder)
            {
                actor.transform.position = new Vector3(rightBorder, actor.transform.position.y, actor.transform.position.z);
                timer = timerValue;
            }
            else if (actor.transform.position.x > rightBorder)
            {
                actor.transform.position = new Vector3(leftBorder, actor.transform.position.y, actor.transform.position.z);
                timer = timerValue;
            }
            else if (actor.transform.position.y < lowerEdge)
            {
                actor.transform.position = new Vector3(actor.transform.position.x, upperEdge, actor.transform.position.z);
                timer = timerValue;
            }
            else if (actor.transform.position.y > upperEdge)
            {
                actor.transform.position = new Vector3(actor.transform.position.x, lowerEdge, actor.transform.position.z);
                timer = timerValue;
            }
            
        }     
    }
    public void SpawnAsteroids()
    {
        for(int i = 0; i<numberOfAsteroids;i++) 
        {
            Vector3 position = SelectPosition();
            float rotationdirection = Random.Range(-1, 1);
            float rotationspeed = Random.Range(10,40);           
            Asteroid newAsteroid = Instantiate(asteroid, position, Quaternion.identity);
            asteroidsInGame.Add(newAsteroid);
            newAsteroid.SetStartSpeedandRotation(rotationspeed, rotationdirection);
        }
    }
    private Vector3 SelectPosition() 
    {
        Vector3 position = new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(lowerEdge, UpperEdge), spawnPoint.transform.position.z);
        return position;
    }
}
