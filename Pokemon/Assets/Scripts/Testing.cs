using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

	void OnMouseDown(){
		Person Hugo = new Person ("Hugo", 0, 0, 20);
		Person Montegue = new Person ("Montegue", 0, 0, 20);
		Ability punch = new Ability ("punch", 5, 100);

		Montegue.addAbility (punch);

		print ("Hugo: " + Hugo.health);
		print("Fight Begins");
		print(Montegue.attack (Hugo, 0));
		print ("Hugo: " + Hugo.health);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
