using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayActor : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10;
    [SerializeField]
    protected float radius = 1;
    [SerializeField]
    protected float maxTimerValue = 0.5f;
    protected float timeOfInvulnerability = 0.5f;
    private void Awake()
    {
        timeOfInvulnerability = maxTimerValue;
    }
    public void InvulnerabilityTimerCountDown() 
    {
        if (timeOfInvulnerability > 0) 
        {
            timeOfInvulnerability -= Time.deltaTime;
        }
        else
        {
            timeOfInvulnerability = 0;
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
