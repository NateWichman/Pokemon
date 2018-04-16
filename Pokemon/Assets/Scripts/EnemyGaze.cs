using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the "enemy gaze" which triggers a battle 
/// </summary>
public class EnemyGaze : MonoBehaviour
{
    /// <summary>
    /// The enemy
    /// </summary>
    public GameObject enemy;

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
        if (enemy.GetComponent<Person>().defeated)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called when [trigger enter2 d].
    /// </summary>
    /// <param name="col">The col.</param>
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<PlayerMovement>())
        {
            gm.GetComponent<GameManager>().enemy = enemy;
            gm.EnterBattle();
        }
    }
}
