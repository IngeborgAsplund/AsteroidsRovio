using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpaceShipTests
{  
    [UnityTest]
    public IEnumerator NoMoreThanOneSpaceShipInScene()
    {
        GameManager gameManager = new GameObject().AddComponent<GameManager>();
        GameBoard board = new GameObject().AddComponent<GameBoard>();    
        Assert.NotNull(gameManager);
        Assert.NotNull(board);
        yield return new WaitForSeconds(2);
        Spaceship shipOne = new GameObject().AddComponent<Spaceship>();
        Spaceship shipTwo = new GameObject().AddComponent<Spaceship>();
        Spaceship shipthree = new GameObject().AddComponent<Spaceship>();
        Assert.AreEqual(board.Player, shipOne);       
    }
}
