using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public string name;
    public int attack_Bonus;
    public int dexterity_Bonus;
    public int health;

    //This array holds the person's four abilities.
    public Ability[] abilities = new Ability[4];

    //Constructor
    public Person(string name, int attack_Bonus, int dexterity_Bonus, int health)
    {
        this.name = name;
        this.attack_Bonus = attack_Bonus;
        this.dexterity_Bonus = dexterity_Bonus;
        this.health = health;
    }

    public string attack(Person opponent, int ability_Index)
    {
        string text = "Error, if statement not activated";
        if ((int)Random.Range(0, 100) + dexterity_Bonus > abilities[ability_Index].chance_to_miss)
        {
            opponent.health -= abilities[ability_Index].attack_Damage;
            text = name + " used " + abilities[ability_Index].name + " on " + opponent.name + ":  " + "Attack Succesful!";
        }
        else
        {
            text = name + " used " + abilities[ability_Index].name + " on " + opponent.name + ":  " + "Attack missed.....";
        }
        return text;
    }

    public void addAbility(Ability ability)
    {
        for (int i = 0; i < 4; i++)
        {
            if (abilities[i] == null)
            {
                abilities[i] = ability;
                break;
            }
        }
    }

    public void replaceAbility(Ability ability, int index)
    {
        abilities[index] = ability;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}