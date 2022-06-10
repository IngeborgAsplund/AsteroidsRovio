using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : GamePlayActor
{
    [SerializeField]
    private GameObject bullet;
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            Move();
        }
    }
    private void Fire() 
    {
    }
    private void Move() 
    {
        transform.Translate(transform.up *speed*Time.deltaTime);
        GameManager.Instance.Board.ObjectCrossedBorder(this.gameObject);
    }
    private void Rotate() 
    {
    }
    private void Teleport() 
    {
    }
}
