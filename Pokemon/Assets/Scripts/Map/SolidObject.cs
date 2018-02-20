using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObject : MonoBehaviour {

	private GameManager gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		//When anything goes inside of the collider "col" this code will run
		if (col.GetComponent<northOfPlayer> ()) {
			gm.SolidObjectHit (Direction.North);
		}
		if (col.GetComponent<eastOfPlayer> ()) {
			gm.SolidObjectHit (Direction.East);
		}
		if (col.GetComponent<southOfPlayer> ()) {
			gm.SolidObjectHit (Direction.South);
		}
		if (col.GetComponent<westOfPlayer> ()) {
			gm.SolidObjectHit (Direction.West);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.GetComponent<northOfPlayer> ()) {
			gm.SolidObjectLeft();
		}
		if (col.GetComponent<eastOfPlayer> ()) {
			gm.SolidObjectLeft();
		}
		if (col.GetComponent<southOfPlayer> ()) {
			gm.SolidObjectLeft ();
		}
		if (col.GetComponent<westOfPlayer> ()) {
			gm.SolidObjectLeft ();
		}
	}
}

public enum Direction{
	North,
	East,
	South,
	West
}