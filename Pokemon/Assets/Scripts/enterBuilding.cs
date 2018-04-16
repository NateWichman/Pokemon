using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the player moving in and out of buildings 
/// </summary>
public class enterBuilding : MonoBehaviour
{
    /// <summary>
    /// The exit point
    /// </summary>
    public GameObject exitPoint;

    /// <summary>
    /// The player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The north
    /// </summary>
    public GameObject North;

    /// <summary>
    /// The east
    /// </summary>
    public GameObject East;

    /// <summary>
    /// The south
    /// </summary>
    public GameObject South;

    /// <summary>
    /// The west
    /// </summary>
    public GameObject West;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    public void Update()
    {
    }

    /// <summary>
    /// Called when [trigger stay2 d].
    /// </summary>
    /// <param name="col">The col.</param>
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            var endPosition = exitPoint.transform.position;
            var startPosition = player.transform.position;
            player.transform.position = endPosition;
            var moveDelta = player.transform.position - startPosition;
            Camera.main.transform.position += moveDelta;
            North.transform.position += moveDelta;
            East.transform.position += moveDelta;
            South.transform.position += moveDelta;
            West.transform.position += moveDelta;
        }
    }
}