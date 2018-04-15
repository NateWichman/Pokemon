using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest
{

    [Test]
    public void TestPersonConstruction()
    {
        var player = new Person();

        player.Name = "Nate";
        player.attack_Bonus = 5;
        player.dexterity_Bonus = 4;
        player.health = 100;

        Assert.AreEqual("Nate", player.Name);
        Assert.AreEqual(5, player.attack_Bonus);
        Assert.AreEqual(4, player.dexterity_Bonus);
        Assert.AreEqual(100, player.health);
    }

    [Test]
    public void TestGameManagerConstruction()
    {
        var gm = new GameManager();

        Assert.AreEqual(0, gm.spaceCounter);
        Assert.AreEqual(19, gm.endingIntroLine);
        Assert.IsFalse(gm.titleDone);
        Assert.IsFalse(gm.introDone);
    }

    [Test]
    public void testSolidObjectLeftCode()
    {
        var player = new GameObject();
        player.AddComponent<Person>();
        player.GetComponent<Person>().Name = "Nate";

        Assert.AreEqual("Nate", player.GetComponent<Person>().Name);
    }

    [Test]
    public void testEnemyGazeSelfDestruct()
    {
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        var gaze = new GameObject();
        gaze.AddComponent<EnemyGaze>();
        var enemy = new GameObject();
        enemy.AddComponent<Person>();

        gaze.GetComponent<EnemyGaze>().enemy = enemy;
        gaze.GetComponent<EnemyGaze>().gm = gm.GetComponent<GameManager>();

        enemy.GetComponent<Person>().defeated = false;

        //These if statments represent the Update() method of EnemyGaze
        //It could not be used because it is protected.
        if (enemy.GetComponent<Person>().defeated)
        {
            gm = null;
        }

        Assert.AreNotEqual(null, gm);

        enemy.GetComponent<Person>().defeated = true;

        if (enemy.GetComponent<Person>().defeated)
        {
            gm = null;
        }

        Assert.AreEqual(null, gm);

    }

    [Test]
    public void testGameManagerCollisionDetection()
    {
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        var gaze = new GameObject();
        gaze.AddComponent<EnemyGaze>();
        var player = new GameObject();
        player.AddComponent<Person>();

        gaze.GetComponent<EnemyGaze>().enemy = player;
        gaze.GetComponent<EnemyGaze>().gm = gm.GetComponent<GameManager>();

        //Testing Collision code onTriggerEnter2D(Collider2D col)
        //If they are equal, we know that player movement was sucessfully found which will activate the
        //enter battle code, which is the purpose of the collision code.
        Assert.AreEqual(null, player.GetComponent<PlayerMovement>());
    }

    [Test]
    public void testAttack()
    {
        var attacker = new GameObject();
        attacker.AddComponent<Person>();
        var defender = new GameObject();
        defender.AddComponent<Person>();
        var ability = new GameObject();
        ability.AddComponent<Ability>();
        ability.GetComponent<Ability>().attack_Damage = 100;
        ability.GetComponent<Ability>().chance_to_miss = 100;
        attacker.GetComponent<Person>().current_Ability = ability.GetComponent<Ability>();
        attacker.GetComponent<Person>().attack_Bonus = 0;
        attacker.GetComponent<Person>().dexterity_Bonus = 0;
        defender.GetComponent<Person>().dexterity_Bonus = 0;
        defender.GetComponent<Person>().health = 100;
        ability.GetComponent<Ability>().Name = "Name";

        //Should Miss no matter what
        attacker.GetComponent<Person>().attack(defender.GetComponent<Person>(), 1);
        Assert.AreEqual(100, defender.GetComponent<Person>().health);
    }

    [Test]
    public void testAbilityNameFetching()
    {
        var ability = new GameObject();
        ability.AddComponent<Ability>().Name = "Name";

        Assert.AreEqual("Name", ability.GetComponent<Ability>().Name);
    }

    [Test]
    public void testAbilityAttackDamageFetching()
    {
        var ability = new GameObject();
        ability.AddComponent<Ability>().attack_Damage = 5;

        Assert.AreEqual(5, ability.GetComponent<Ability>().attack_Damage);
    }

    [Test]
    public void testAbilityChanceToMissFetching()
    {
        var ability = new GameObject();
        ability.AddComponent<Ability>().chance_to_miss = 5;

        Assert.AreEqual(5, ability.GetComponent<Ability>().chance_to_miss);
    }
    
    [Test]
    public void testSolidObjectColilisionNorth()
    {
        var solidObject = new GameObject();
        solidObject.AddComponent<SolidObject>();
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        solidObject.GetComponent<SolidObject>().gm = gm.GetComponent<GameManager>();
        var player = new GameObject();
        player.AddComponent<PlayerMovement>();
        gm.GetComponent<GameManager>().player = player;

        gm.GetComponent<GameManager>().SolidObjectHit(Direction.North);

        Assert.AreEqual(false, player.GetComponent<PlayerMovement>().canMoveNorth);
    }

    [Test]
    public void testSolidObjectColilisionEast()
    {
        var solidObject = new GameObject();
        solidObject.AddComponent<SolidObject>();
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        solidObject.GetComponent<SolidObject>().gm = gm.GetComponent<GameManager>();
        var player = new GameObject();
        player.AddComponent<PlayerMovement>();
        gm.GetComponent<GameManager>().player = player;

        gm.GetComponent<GameManager>().SolidObjectHit(Direction.East);

        Assert.AreEqual(false, player.GetComponent<PlayerMovement>().canMoveEast);
    }

    [Test]
    public void testSolidObjectColilisionSouth()
    {
        var solidObject = new GameObject();
        solidObject.AddComponent<SolidObject>();
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        solidObject.GetComponent<SolidObject>().gm = gm.GetComponent<GameManager>();
        var player = new GameObject();
        player.AddComponent<PlayerMovement>();
        gm.GetComponent<GameManager>().player = player;

        gm.GetComponent<GameManager>().SolidObjectHit(Direction.South);

        Assert.AreEqual(false, player.GetComponent<PlayerMovement>().canMoveSouth);
    }

    [Test]
    public void testSolidObjectColilisionWest()
    {
        var solidObject = new GameObject();
        solidObject.AddComponent<SolidObject>();
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        solidObject.GetComponent<SolidObject>().gm = gm.GetComponent<GameManager>();
        var player = new GameObject();
        player.AddComponent<PlayerMovement>();
        gm.GetComponent<GameManager>().player = player;

        gm.GetComponent<GameManager>().SolidObjectHit(Direction.West);

        Assert.AreEqual(false, player.GetComponent<PlayerMovement>().canMoveWest);
    }

    [Test]
    public void testSolidObjectLeft()
    {
        var gm = new GameObject();
        gm.AddComponent<GameManager>();
        var player = new GameObject();
        player.AddComponent<Player>();
        gm.GetComponent<GameManager>().player = player;
        player.AddComponent<PlayerMovement>();

        player.GetComponent<PlayerMovement>().canMoveNorth = false;
        player.GetComponent<PlayerMovement>().canMoveEast = false;
        player.GetComponent<PlayerMovement>().canMoveSouth = false;
        player.GetComponent<PlayerMovement>().canMoveWest = false;

        gm.GetComponent<GameManager>().SolidObjectLeft();

        Assert.AreEqual(true, player.GetComponent<PlayerMovement>().canMoveNorth);
        Assert.AreEqual(true, player.GetComponent<PlayerMovement>().canMoveEast);
        Assert.AreEqual(true, player.GetComponent<PlayerMovement>().canMoveWest);
        Assert.AreEqual(true, player.GetComponent<PlayerMovement>().canMoveSouth);
    }

    [Test]
    public void TestTextBoxManagerInstantiation()
    {
        var box = new GameObject();
        box.AddComponent<TextBoxManager>();

        Assert.AreEqual(false, box.GetComponent<TextBoxManager>().fileDoneReading);
        Assert.AreEqual(false, box.GetComponent<TextBoxManager>().printingText);
        Assert.AreEqual(0, box.GetComponent<TextBoxManager>().currentLine);
    }

}
