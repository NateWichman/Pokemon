using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class GameManager : MonoBehaviour {

	/*
		Testing if I can push stuff from git to my computer by seeing if this notes shows up - Nate
	*/
	public GameObject playerCamera;
	public GameObject battleCamera;

	public GameObject player;
	public GameObject northOfPlayer;

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		playerCamera.SetActive (true);
		battleCamera.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		offset = northOfPlayer.transform.position - player.transform.position;
	}

	void LateUpdate(){
		northOfPlayer.transform.position = player.transform.position + offset;
	}
		
	public void EnterBattle(){
		playerCamera.active = false;
		battleCamera.active = true;

		player.GetComponent<PlayerMovement>().isAllowedToMove = false;
	}

	public void SolidObjectHit(){
		player.GetComponent<PlayerMovement> ().isAllowedToMoveNorth = false;
		print ("hit");
	}
	public void SolidObjectLeft(){
		player.GetComponent<PlayerMovement> ().isAllowedToMoveNorth = true;
		print ("Left");
	}
}
