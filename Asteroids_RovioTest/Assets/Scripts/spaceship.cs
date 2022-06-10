using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : GamePlayActor
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float turnspeed;
    private Rigidbody2D rigidBody;
    private bool thrusting;
    private float turnDirection;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            turnDirection = 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            turnDirection = -1.0f;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            turnDirection = 0.0f;
        }
        GameManager.Instance.Board.ObjectCrossedBorder(gameObject);
    }
    private void FixedUpdate()
    {
        if (thrusting) 
        {
            Move();            
        }
        if (turnDirection != 0.0f) 
        {
            Rotate();
        }
        
    }
    private void Fire() 
    {
    }
    private void Move() 
    {       
        rigidBody.AddForce(this.transform.up * speed);
        
    }
    private void Rotate() 
    {
        rigidBody.AddTorque(turnDirection*turnspeed);       
    }
    private void Teleport() 
    {
    }
}
