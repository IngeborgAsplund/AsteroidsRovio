using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class GameBoardTests
{
    [UnityTest]
    public IEnumerator MovedOverUpperEdge()
    {
        GameObject boardObject = new GameObject();
        GameObject managerObject = new GameObject();
        GameManager manager = managerObject.AddComponent<GameManager>();
        GameBoard board= boardObject.AddComponent<GameBoard>();
        board.SpawnPoint = new GameObject().transform;
        GameObject moveObject = new GameObject();
        moveObject.transform.position = new Vector3(0, 6, 0);
        board.Timer = 0.0f;
        board.ObjectCrossedBorder(moveObject);
        Vector3 expectedPosition = new Vector3(0,board.LowerEdge, 0);
        yield return new WaitForSeconds(2);
        Assert.IsNotNull(manager);
        Assert.IsNotNull(board);
        Assert.IsNotNull(board.SpawnPoint);
        Assert.AreEqual(expectedPosition, moveObject.transform.position);
    }
    [UnityTest]
    public IEnumerator MovedOverLowerEdge ()
    {
        GameObject boardObject = new GameObject();
        GameObject managerObject = new GameObject();
        GameManager manager = managerObject.AddComponent<GameManager>();
        GameBoard board = boardObject.AddComponent<GameBoard>();
        board.SpawnPoint = new GameObject().transform;
        GameObject moveObject = new GameObject();
        moveObject.transform.position = new Vector3(0, -6, 0);
        board.Timer = 0.0f;
        board.ObjectCrossedBorder(moveObject);
        Vector3 expectedPosition = new Vector3(0, board.UpperEdge, 0);
        yield return new WaitForSeconds(2);
        Assert.IsNotNull(manager);
        Assert.IsNotNull(board);
        Assert.IsNotNull(board.SpawnPoint);
        Assert.AreEqual(expectedPosition, moveObject.transform.position);
    }
    [UnityTest]
    public IEnumerator MovedOverLeftEdge ()
    {
        GameObject boardObject = new GameObject();
        GameObject managerObject = new GameObject();
        GameManager manager = managerObject.AddComponent<GameManager>();
        GameBoard board = boardObject.AddComponent<GameBoard>();
        board.SpawnPoint = new GameObject().transform;
        GameObject moveObject = new GameObject();
        moveObject.transform.position = new Vector3(-10, 0, 0);
        board.Timer = 0.0f;
        board.ObjectCrossedBorder(moveObject);
        Vector3 expectedPosition = new Vector3(board.RightBorder, 0, 0);
        yield return new WaitForSeconds(2);
        Assert.IsNotNull(manager);
        Assert.IsNotNull(board);
        Assert.IsNotNull(board.SpawnPoint);
        Assert.AreEqual(expectedPosition, moveObject.transform.position);
    }
    [UnityTest]
   public IEnumerator MovedOverRightEdge() 
    {
        GameObject boardObject = new GameObject();
        GameObject managerObject = new GameObject();
        GameManager manager = managerObject.AddComponent<GameManager>();
        GameBoard board = boardObject.AddComponent<GameBoard>();
        board.SpawnPoint = new GameObject().transform;
        GameObject moveObject = new GameObject();
        moveObject.transform.position = new Vector3(10, 0, 0);
        board.Timer = 0.0f;
        board.ObjectCrossedBorder(moveObject);
        Vector3 expectedPosition = new Vector3(board.LeftBorder, 0, 0);
        yield return new WaitForSeconds(2);
        Assert.IsNotNull(manager);
        Assert.IsNotNull(board);
        Assert.IsNotNull(board.SpawnPoint);
        Assert.AreEqual(expectedPosition, moveObject.transform.position);
    }
}
