using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles 
/// </summary>
public class Person : MonoBehaviour
{
    /// <summary>
    /// The name
    /// </summary>
    public string Name;

    /// <summary>
    /// The attack bonus
    /// </summary>
    public int attack_Bonus;

    /// <summary>
    /// The dexterity bonus
    /// </summary>
    public int dexterity_Bonus;

    /// <summary>
    /// The health
    /// </summary>
    public int health;

    /// <summary>
    /// The defeated
    /// </summary>
    public bool defeated = false;

    /// <summary>
    /// The credits
    /// </summary>
    public int credits = 0;

    /// <summary>
    /// The battle sprite
    /// </summary>
    public Sprite BattleSprite;

    /// <summary>
    /// The current ability
    /// </summary>
    public Ability current_Ability;

    /// <summary>
    /// Attacks the specified opponent.
    /// </summary>
    /// <param name="opponent">The opponent.</param>
    /// <param name="ability_Index">Index of the ability.</param>
    /// <returns name="attackHit">Did the attack hit</returns>
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

    /// <summary>
    /// Gets the name of the ability.
    /// </summary>
    /// <returns name="current_Ability.Name">The name of the current ability</returns>
    public string getAbilityName()
    {
        return current_Ability.Name;
    }

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    public void Update()
    {
    }
}