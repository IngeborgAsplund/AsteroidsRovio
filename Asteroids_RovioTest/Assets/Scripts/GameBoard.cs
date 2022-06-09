using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 spawnPoint;
    [SerializeField]
    private float rightBorder;
    [SerializeField]
    private float leftBorder;
    [SerializeField]
    private float upperEdge;
    [SerializeField]
    private float lowerEdge;

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            
        }
    }
}
