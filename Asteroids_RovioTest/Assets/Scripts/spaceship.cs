using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : GamePlayActor
{
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private Transform bulletSpawnPoint;
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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Fire();
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
        Projectile newProjectile = Instantiate(bullet, bulletSpawnPoint.transform.position,bulletSpawnPoint.transform.rotation);
        newProjectile.Project(this.transform.up);
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
    public override void Destruction()
    {
        GameManager.Instance.Board.DecreaseALife();
        base.Destruction();
    }
}
