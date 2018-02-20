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
		if (col.GetComponent<PlayerMovement> ()) {
			gm.SolidObjectHit ();
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.GetComponent<PlayerMovement> ()) {
			gm.SolidObjectLeft ();
		}
	}
}
