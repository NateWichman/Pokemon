using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public string Name;
    public int attack_Bonus;
    public int dexterity_Bonus;
    public int health;

    //This array holds the person's four abilities.

    //Constructor
    /*
    public Person(string name, int attack_Bonus, int dexterity_Bonus, int health)
    {
        this.name = name;
        this.attack_Bonus = attack_Bonus;
        this.dexterity_Bonus = dexterity_Bonus;
        this.health = health;
    } */

    public void attack(Person opponent, int ability_Index)
    {
        if ((int)Random.Range(0, 100) + dexterity_Bonus > GetComponent<Ability>().chance_to_miss)
        {
            /*
            opponent.health -= abilities[ability_Index].attack_Damage;
            text = name + " used " + abilities[ability_Index].name + " on " + opponent.name + ":  " + "Attack Succesful!";
            */
            opponent.health -= GetComponent<Ability>().attack_Damage;
            print( Name + " used " + GetComponent<Ability>().Name + " on " + opponent.Name + ":  " + "Attack Succesful!");
        }
        else
        {
           // text = name + " used " + abilities[ability_Index].name + " on " + opponent.name + ":  " + "Attack missed.....";
            print(Name + " used " + GetComponent<Ability>().Name + " on " + opponent.Name + ":  " + "Attack missed.....");
        }
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