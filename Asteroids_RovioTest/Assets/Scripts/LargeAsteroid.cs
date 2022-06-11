using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroid : Asteroid
{
    [SerializeField]
    Asteroid asteroidToSpawnOnDestruction;

    public override void Destruction()
    {

        base.Destruction();
    }
}
