using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterBuilding : MonoBehaviour
{
    public GameObject exitPoint;
    public GameObject player;
    public GameObject North;
    public GameObject East;
    public GameObject South;
    public GameObject West;

   // private GameManager gm;
    // Use this for initialization
    void Start()
    {
    //    gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
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