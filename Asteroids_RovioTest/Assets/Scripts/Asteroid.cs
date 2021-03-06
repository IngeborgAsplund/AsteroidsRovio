using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : GamePlayActor
{
    [SerializeField]
    private int baseScoreValue = 100;
    [SerializeField]
    private int score = 0;
    private Rigidbody2D rigidbody;
    private float size;
    [SerializeField]
    private float minSize = 0.3f;
    [SerializeField]
    private float maxSize = 1.5f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void SetScoreBySize() 
    {
        if (size > 1.2f) 
        {
            score = baseScoreValue/3;
        }
        if(size> 0.75 && size <= 1.2) 
        {
            score = baseScoreValue/2;
        }
        if (size <= 0.75) 
        {
            score = baseScoreValue;
        }
    }
    private void Start()
    {
        size = Random.Range(minSize, maxSize);
        SetScoreBySize();
        transform.localScale = Vector3.one*size;
    }
    private void Update()
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
        GameManager.Instance.Board.CheckNumberOfAsteroids();
        base.Destruction();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Bullet") 
        {
            if ((size/2) > minSize) 
            {               
                for(int i = 0; i<2; i++) 
                {
                    Split();
                }
            }
            Destruction();
        }
        
    }
    private void Split() 
    {
        Vector3 position = transform.position;
        position += Random.insideUnitSphere * radius;
        position.z = this.transform.position.z;
        Asteroid splitOff = Instantiate(this, position, transform.rotation);
        splitOff.SetStartSpeedandRotation(Random.Range(10,40), Random.Range(-1, 1));
        GameManager.Instance.Board.AsteroidsInGame.Add(splitOff);
    }
}
