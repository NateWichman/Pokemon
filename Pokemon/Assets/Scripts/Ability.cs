using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public string name;
    public int attack_Damage;
    public int chance_to_miss;
    // Use this for initialization

    //Constructor
    public Ability(string name, int attack_Damage, int chance_to_miss)
    {
        this.name = name;
        this.attack_Damage = attack_Damage;
        this.chance_to_miss = chance_to_miss;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}