using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This enum handles the direction of the player 
/// </summary>
public enum Direction
{
    /// <summary>
    /// The north
    /// </summary>
    North,

    /// <summary>
    /// The east
    /// </summary>
    East,

    /// <summary>
    /// The south
    /// </summary>
    South,

    /// <summary>
    /// The west
    /// </summary>
    West
}

/// <summary>
/// This class handles object collison 
/// </summary>
public class SolidObject : MonoBehaviour
{
    /// <summary>
    /// The gm
    /// </summary>
    public GameManager gm;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
        print("HIIITTTTT");
        if (col.GetComponent<northOfPlayer>())
        {
            print("Hit North");
            gm.SolidObjectHit(Direction.North);
        }

        if (col.GetComponent<eastOfPlayer>())
        {
            print("Hit East");
            gm.SolidObjectHit(Direction.East);
        }

        if (col.GetComponent<southOfPlayer>())
        {
            print("Hit South");
            gm.SolidObjectHit(Direction.South);
        }

        if (col.GetComponent<westOfPlayer>())
        {
            print("Hit West");
            gm.SolidObjectHit(Direction.West);
        }
    }

    /// <summary>
    /// Called when [trigger exit2 d].
    /// </summary>
    /// <param name="col">The col.</param>
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<northOfPlayer>())
        {
            gm.SolidObjectLeft();
        }

        if (col.GetComponent<eastOfPlayer>())
        {
            gm.SolidObjectLeft();
        }

        if (col.GetComponent<southOfPlayer>())
        {
            gm.SolidObjectLeft();
        }

        if (col.GetComponent<westOfPlayer>())
        {
            gm.SolidObjectLeft();
        }
    }
}
