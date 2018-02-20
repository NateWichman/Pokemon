using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongGrass : MonoBehaviour {


	private GameManager gm;

	// Use this for initialization
	void Start () {
		//Setting the gm object equal to the actual game manager (empty object I made) I think
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		//When anything goes inside of the collider "col" this code will run
		if (col.GetComponent<PlayerMovement> ()) {
	     	// the component colliding has the class player movement attached
			//Probability = x / 187.5
			//VC = 10, C = 8.5, SR = 6.75, Rare = 3.33, VR = 1.25

			//Setting up floats for the probability of finding various pokemon based on rarity
			float vc = 10.0f / 187.5f;
			float c = 8.5f / 187.5f;
			float sr = 6.75f / 187.5f;
			float r = 3.33f / 187.5f;
			float vr = 1.25f / 187.5f;

			//Variable for probability, add the 'f' to ensure it is a float with .0 too
			float p = Random.Range (0.0f, 100.0f);


		    //These ifs determin which rarity should appear,
			//Notice that it starts from vr and goes down to vc
			if (p < vr * 100) {
				if (gm != null) {
					gm.EnterBattle ();
				}
			} else if (p < r * 100) {
				if (gm != null) {
					gm.EnterBattle ();
				}
				
			} else if (p < sr * 100) {
				if (gm != null) {
					gm.EnterBattle ();
				}

			} else if (p < c * 100) {
				if (gm != null) {
					gm.EnterBattle ();
				}

			} else if (p < vc * 100) {
				if (gm != null) {
					gm.EnterBattle ();
				}

			}
		}
	}
}
