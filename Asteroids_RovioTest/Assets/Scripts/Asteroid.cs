using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : GamePlayActor
{
    [SerializeField]
    private int score;
    private Rigidbody2D rigidbody;
    private float size;
    private float maxSize = 0.5f;
    private float minSize = 1.5f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {        
        size = Random.Range(minSize, maxSize);
        transform.localScale = Vector3.one * size;
        rigidbody.mass = size;
    }
    private void FixedUpdate()
    {
        GameManager.Instance.Board.ObjectCrossedBorder(this.gameObject);
    }
    public void SetStartSpeedandRotation(float rotationspeed, float direction) 
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
        rigidbody.AddForce(transform.up * speed);
        rigidbody.AddTorque(direction * rotationspeed);
    }
    public override void Destruction()
    {
        GameManager.Instance.Board.AsteroidsInGame.Remove(this);
        GameManager.Instance.Score.AddNewScore(score);
        base.Destruction();
    }
}
