using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Direction currentDir;
	Vector2 input;
	bool isMoving = false;
	Vector3 startPos;
	Vector3 endPos;
	float t;

	public Sprite northSprite;
	public Sprite eastSprite;
	public Sprite southSprite;
	public Sprite westSprite;

	public float walkSpeed = 3f;
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
			if (Mathf.Abs (input.x) > Mathf.Abs (input.y)) {
				input.y = 0; //Makes it so the player does not move diagnoally
			} 
			else {
				input.x = 0;
			}
			//The below if statement determins the correct enum to change the sprite
			if (input != Vector2.zero) {
				if (input.x < 0){
					currentDir = Direction.West;
				} 
				else if (input.x > 0) {
					currentDir = Direction.East;
				} 
				else if (input.y < 0) {
					currentDir = Direction.South;
				} 
				else if (input.y > 0) {
					currentDir = Direction.North;
				}

				//Changes sprite based on currentDir value found above
				switch (currentDir) {
				case Direction.North:
					gameObject.GetComponent<SpriteRenderer> ().sprite = northSprite;
					break;
				case Direction.East:
					gameObject.GetComponent<SpriteRenderer> ().sprite = eastSprite;
					break;
				case Direction.South:
					gameObject.GetComponent<SpriteRenderer> ().sprite = southSprite;
					break;
				case Direction.West:
					gameObject.GetComponent<SpriteRenderer> ().sprite = westSprite;
					break;
				}
				StartCoroutine (Move (transform));
			}
		}
	}

	public IEnumerator Move(Transform entity){
		isMoving = true; //Signalling that the player is moving
		startPos = entity.position; //Putting variable startPos to be the players current position
		t = 0; //Reseting time to 0

		endPos = new Vector3 (startPos.x + System.Math.Sign (input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

		while (t < 1f) {
			t += Time.deltaTime * walkSpeed;
			entity.position = Vector3.Lerp (startPos, endPos, t);
			yield return null;
		}

		isMoving = false;
		yield return 0;
	}
}

enum Direction{
	North,
	East,
	South,
	West
}