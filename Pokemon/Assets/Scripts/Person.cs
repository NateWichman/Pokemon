using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    public string Name;
    public int attack_Bonus;
    public int dexterity_Bonus;
    public int health;
    public bool defeated = false;
    public int credits = 0;

    public Sprite BattleSprite;

    public Ability current_Ability;

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

    public bool attack(Person opponent, int ability_Index)
    {
        bool attackHit = false;
        switch (ability_Index)
        {
            case 1:
                current_Ability = GetComponent<Ability>();
                break;
            default:
                print("Error: No ability found");
                break;
        }
        if ((int)Random.Range(0, 100) + dexterity_Bonus > current_Ability.chance_to_miss)
        {
            opponent.health -= GetComponent<Ability>().attack_Damage;
            attackHit = true;
        }
        else
        {
           // text = name + " used " + abilities[ability_Index].name + " on " + opponent.name + ":  " + "Attack missed.....";
            print(Name + " used " + GetComponent<Ability>().Name + " on " + opponent.Name + ":  " + "Attack missed.....");
        }
        return attackHit;
    }

    public string getAbilityName()
    {
        return current_Ability.Name;
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