using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour {

	public string Name;
	public Sprite image;
	public BiomeList biomeFound;
	public PokemonType type;
	public float baseHP;
	private float maxHP;
	public float baseAttack;
	public float maxAttack;
	public float baseDef;
	public float maxDef;
	public float speed;
	public Rarity rarity; 
	public Stat HPStat;
	public Stat AttackStat;
	public Stat DefencesStat;

	public bool canEvolve;
	public PokemonEvolution evolveTo;

	private int level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum Rarity{
	VeryCommon,
	Common,
	SemiRare,
	Rare,
	VeryRare
}

public enum PokemonType{
	Flying,
	Ground,
	Rock,
	Steel,
	Fire,
	Water,
	Grass,
	Ice,
	Electric,
	Psychic,
	Dark,
	Dragon,
	Fighting,
	Normal
}

//This command allows you to "edit it in the editor"
[System.Serializable] 
public class PokemonEvolution{
	public BasePokemon nextEvolution;
	public int levelUpLevel;
}