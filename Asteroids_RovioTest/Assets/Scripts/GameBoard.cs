using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Spaceship player;
    [SerializeField]
    int numberOfAsteroids = 10;
    [SerializeField]
    Asteroid asteroid;
    private List<Asteroid> asteroidsInGame;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timerValue = 0.2f;
    [SerializeField]
    private float rightBorder = 9.21f;
    [SerializeField]
    private float leftBorder = -9.19f;
    [SerializeField]
    private float upperEdge = 5.11f;
    [SerializeField]
    private float lowerEdge = -5.09f;
    [SerializeField]
    int maxlives = 5;
    int currentLives = 0;
    private float timer = .1f;
    
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
        get { return upperEdge; }
    }
    public float LowerEdge 
    {
        get { return lowerEdge; }
    }
    public Transform SpawnPoint 
    {
        get { return spawnPoint; }
        set { spawnPoint = value; }
    }
    public float Timer 
    {
        set { timer = value; }
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
        currentLives = maxlives;
    }

    public void DecreaseALife() 
    {
        currentLives--;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameManager.Instance.GameGUI.UpdateLivesLabel(currentLives);
        if (currentLives > 0) 
        {           
            Invoke("SpawnPlayer", 1f);
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
        Vector3 position = new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(lowerEdge, upperEdge), spawnPoint.transform.position.z);
        if (player.TransformWithinradius(position)) 
        {
            position = new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(lowerEdge, upperEdge), spawnPoint.transform.position.z);
            Debug.Log(position);
        }
        if (asteroidsInGame.Count > 0) 
        {
            for(int i = 0; i < asteroidsInGame.Count; i++) 
            {
                if (asteroidsInGame[i].TransformWithinradius(position)) 
                {
                    position = new Vector3(Random.Range(leftBorder, rightBorder), Random.Range(lowerEdge, upperEdge),spawnPoint.transform.position.z);
                    Debug.Log(position);
                }
            }
        }
        return position;
    }
    public void CheckNumberOfAsteroids() 
    {
        if (asteroidsInGame.Count < 2&&!GameManager.Instance.GameOver) 
        {
            SpawnAsteroids();
        }
    }
    public void ClearGameBoard() 
    {
        for(int i = 0; i <asteroidsInGame.Count; i++) 
        {
            Destroy(asteroidsInGame[i].gameObject);
        }
        asteroidsInGame.Clear();
    }
    public Vector3 TeleportSpawn() 
    {
        float randomX = Random.Range(leftBorder, rightBorder);
        float randomY = Random.Range(lowerEdge, upperEdge);
        return new Vector3(randomX, randomY, spawnPoint.position.z);
    }
}
