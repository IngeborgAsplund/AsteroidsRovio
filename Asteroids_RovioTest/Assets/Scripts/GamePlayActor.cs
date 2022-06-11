using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayActor : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float radius;

    private void Update()
    {
        if (GameManager.Instance.GameOver) 
        {
            Destruction();
        }
    }
    public virtual void Destruction() 
    {
        Destroy(this.gameObject);
    }
    public bool TransformWithinradius(Vector3 incommingPosition) 
    {
        Vector3 offset = incommingPosition - this.transform.position;
        float squarelenght = offset.sqrMagnitude;
        if (squarelenght < radius * radius) 
        {
            return true;
        }
        return false;
    }
    
}
