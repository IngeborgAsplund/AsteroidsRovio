using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : GamePlayActor
{
    [SerializeField]
    private Projectile bullet;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float turnspeed;
    private Rigidbody2D rigidBody;
    private float turnDirection;

    private void Awake()
    {
        if(GameManager.Instance.Board.Player == null) 
        {
            GameManager.Instance.Board.Player = this;
            rigidBody = GetComponent<Rigidbody2D>();
        }
        else
        {
            Destruction();
        }
        
    }
    private void Update()
    {
        TakeInput();
        GameManager.Instance.Board.ObjectCrossedBorder(gameObject);
        InvulnerabilityTimerCountDown();
    }
    private void FixedUpdate()
    {
        if (Controls.Thrusting()) 
        {
            Move();            
        }
        if (DetermineTurnDirection() != 0.0f) 
        {
            Rotate();
        }      
        
    }
    private float DetermineTurnDirection() 
    {
        if (Controls.TurnRight()) 
        {
            turnDirection = -1.0f;
            return turnDirection;
        }
        if (Controls.TurnLeft()) 
        {
            turnDirection = 1.0f;
            return turnDirection;
        }
        turnDirection = 0.0f;
        return 0.0f;
    }
    private void TakeInput() 
    {
        if (!GameManager.Instance.GameOver)
        {                      
            if (Controls.Firing())
            {
                Fire();
            }
            if (Controls.Teleporting())
            {
                Teleport();
            }
        }
        
    }
    private void Fire() 
    {
        timeOfInvulnerability = maxTimerValue;
        Projectile newProjectile = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
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
        transform.position = GameManager.Instance.Board.TeleportSpawn();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bullet"&&timeOfInvulnerability > 0) 
        {
            return;
        }
        GameManager.Instance.Board.DecreaseALife();
        timeOfInvulnerability = maxTimerValue;
    }

}
