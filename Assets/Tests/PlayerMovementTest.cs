using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    private GameObject playerObject;
    private Player player;
    private Rigidbody2D rb;

    [SetUp]
    public void Setup()
    {
        playerObject = new GameObject();
        player = playerObject.AddComponent<Player>();

        rb = playerObject.AddComponent<Rigidbody2D>();

        player.moveSpeed = 5f;
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(playerObject);
    }

    [UnityTest]
    public IEnumerator PlayerMovesVertically()
    {
        playerObject.transform.position = Vector3.zero;
        Input.SetAxis("Vertical", 1f);  

        player.Update();

        yield return null;

        Assert.AreNotEqual(0, playerObject.transform.position.y);
    }

    [UnityTest]
    public IEnumerator PlayerMovesHorizontally()
    {
       
        playerObject.transform.position = Vector3.zero;
        Input.SetAxis("Horizontal", 1f);  

        player.Update();

        yield return null;

        Assert.AreNotEqual(0, playerObject.transform.position.x);
    }
}
