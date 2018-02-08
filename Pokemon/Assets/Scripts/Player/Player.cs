using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//This list is of the object type of the BasePokemon class
	//it will allow us to keep track of what pokemon the user owns
	public List<BasePokemon> ownedPokemon = new List<BasePokemon>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public class OwnedPokemon{
	public string NickName;
	public BasePokemon pokemon;
	public int level;
	public List<PokemonMoves> moves = new List<PokemonMoves>();
}