using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayActor : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float velocity;
    [SerializeField]
    protected float radius;
    
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
