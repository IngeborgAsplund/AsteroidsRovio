using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : GamePlayActor
{
    [SerializeField]
    private float lifeTime;
    [SerializeField]
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        LifeTimeCount();
        GameManager.Instance.Board.ObjectCrossedBorder(this.gameObject);
    }
    public void Project (Vector2 direction) 
    {
        rigidBody.AddForce(direction * speed);
    }
    private void LifeTimeCount() 
    {
        if (lifeTime > 0.0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else 
        { 
            Destruction(); 
        }
    }
}
