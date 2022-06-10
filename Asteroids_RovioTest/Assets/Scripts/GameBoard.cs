using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private spaceship player;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float rightBorder;
    [SerializeField]
    private float leftBorder;
    [SerializeField]
    private float upperEdge;
    [SerializeField]
    private float lowerEdge;
    [SerializeField]
    int Maxlives;
    int currentLives;

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
    void Start()
    {
        GameManager.Instance.Board = this;
    }
    public void SetStartingLives() 
    {
        currentLives = Maxlives;
    }
      
    public void SpawnPlayer() 
    {
        Instantiate(player.gameObject, spawnPoint);
        GameManager.Instance.GameGUI.UpdateLivesLabel(currentLives);
    }

    public void ObjectCrossedBorder(GameObject actor) 
    {
        
        if (actor.transform.position.x < leftBorder) 
        {
            actor.transform.position = new Vector3(rightBorder, actor.transform.position.y, actor.transform.position.z);           
        }
        else if (actor.transform.position.x > rightBorder) 
        {
            actor.transform.position = new Vector3(leftBorder, actor.transform.position.y, actor.transform.position.z);
        }
        else if (actor.transform.position.y < lowerEdge) 
        {
            actor.transform.position = new Vector3(actor.transform.position.x, upperEdge, actor.transform.position.z);
        }
        else if (actor.transform.position.y > upperEdge) 
        {
            actor.transform.position = new Vector3(actor.transform.position.x, lowerEdge, actor.transform.position.z);
        }
        actor.transform.Rotate(new Vector3(0, 0, 180));
    }
}
