using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class controls the game function 
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The enemy
    /// </summary>
    public GameObject enemy;

    /// <summary>
    /// The player camera
    /// </summary>
    public GameObject playerCamera;

    /// <summary>
    /// The battle camera
    /// </summary>
    public GameObject battleCamera;

    /// <summary>
    /// The library camera1
    /// </summary>
    public GameObject libraryCamera1;

    /// <summary>
    /// The title camera
    /// </summary>
    public GameObject titleCamera;

    /// <summary>
    /// The intro camera
    /// </summary>
    public GameObject introCamera;

    /// <summary>
    /// The player
    /// </summary>
    public GameObject player;

    /// <summary>
    /// The north of player
    /// </summary>
    public GameObject northOfPlayer;

    /// <summary>
    /// The east of player
    /// </summary>
    public GameObject eastOfPlayer;

    /// <summary>
    /// The south of player
    /// </summary>
    public GameObject southOfPlayer;

    /// <summary>
    /// The west of player
    /// </summary>
    public GameObject westOfPlayer;

    /// <summary>
    /// The space counter
    /// </summary>
    public int spaceCounter = 0;

    /// <summary>
    /// The ending intro line
    /// </summary>
    public int endingIntroLine = 19;

    /// <summary>
    /// The title done
    /// </summary>
    public bool titleDone = false;

    /// <summary>
    /// The intro done
    /// </summary>
    public bool introDone = false;

    /// <summary>
    /// The intro text reader
    /// </summary>
    public GameObject introTextReader;

    /// <summary>
    /// The battle text
    /// </summary>
    public Text battleText;

    /// <summary>
    /// The ability one text
    /// </summary>
    public Text abilityOneText;

    /// <summary>
    /// The ability two text
    /// </summary>
    public Text abilityTwoText;

    /// <summary>
    /// The ability three text
    /// </summary>
    public Text abilityThreeText;

    /// <summary>
    /// The ability four text
    /// </summary>
    public Text abilityFourText;

    /// <summary>
    /// The enemy health text
    /// </summary>
    public Text enemyHealthText;

    /// <summary>
    /// The player health text
    /// </summary>
    public Text playerHealthText;

    /// <summary>
    /// The current ability number
    /// </summary>
    public int current_Ability_Number;

    /// <summary>
    /// The battle enemy sprite
    /// </summary>
    public GameObject BattleEnemySprite;

    /// <summary>
    /// The battle player sprite
    /// </summary>
    public GameObject BattlePlayerSprite;

    /// <summary>
    /// The offset n
    /// </summary>
    private Vector3 offsetN;

    /// <summary>
    /// The offset e
    /// </summary>
    private Vector3 offsetE;

    /// <summary>
    /// The offset s
    /// </summary>
    private Vector3 offsetS;

    /// <summary>
    /// The offset w
    /// </summary>
    private Vector3 offsetW;

    /// <summary>
    /// The offset camera1
    /// </summary>
    private Vector3 offsetCamera1;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    public void Start()
    {
        titleCamera.SetActive(true);
        introCamera.SetActive(false);
        playerCamera.SetActive(false);
        battleCamera.SetActive(false);
        libraryCamera1.SetActive(false);
        player.GetComponent<PlayerMovement>().isAllowedToMove = false;
    }

    /// <summary>
    /// Updates this instance.
    /// </summary>
    public void Update()
    {
        if (!titleDone)
        {
            SwitchToIntro();
        }

        if (!introDone)
        {
            SwitchToPlayer();
        }

        offsetN = northOfPlayer.transform.position - player.transform.position;
        offsetE = eastOfPlayer.transform.position - player.transform.position;
        offsetS = southOfPlayer.transform.position - player.transform.position;
        offsetW = westOfPlayer.transform.position - player.transform.position;
        offsetCamera1 = playerCamera.transform.position - player.transform.position;

        if (player.GetComponent<Person>().credits == 120)
        {
        } 
    }

    /// <summary>
    /// delays the update.
    /// </summary>
    public void LateUpdate()
    {
        northOfPlayer.transform.position = player.transform.position + offsetN;
        eastOfPlayer.transform.position = player.transform.position + offsetE;
        southOfPlayer.transform.position = player.transform.position + offsetS;
        westOfPlayer.transform.position = player.transform.position + offsetW;
        playerCamera.transform.position = player.transform.position + offsetCamera1;
    }

    /// <summary>
    /// Switches to intro.
    /// </summary>
    public void SwitchToIntro()
    {
        if (Input.GetKeyDown(KeyCode.Return) && titleDone == false)
        {
            titleDone = true;
            titleCamera.SetActive(false);
            introCamera.SetActive(true);
        }
    }

    /// <summary>
    /// Switches to player.
    /// </summary>
    public void SwitchToPlayer()
    {
        if (titleDone == true && introDone == false)
        {
            if (introTextReader.GetComponent<TextBoxManager>().fileDoneReading)
            {
                introDone = true;
                introCamera.SetActive(false);
                playerCamera.SetActive(true);
                player.GetComponent<PlayerMovement>().isAllowedToMove = true;
            }
        }
    }

    /// <summary>
    /// Enters the battle.
    /// </summary>
    public void EnterBattle()
    {
        playerCamera.active = false;
        battleCamera.active = true;

        BattleEnemySprite.GetComponent<SpriteRenderer>().sprite = enemy.GetComponent<Person>().BattleSprite;

        player.GetComponent<PlayerMovement>().isAllowedToMove = false;
        abilityOneText.text = player.GetComponent<Ability>().Name;

        enemyHealthText.text = enemy.GetComponent<Person>().Name + "\nHP: " + enemy.GetComponent<Person>().health.ToString();
        playerHealthText.text = "HP: " + player.GetComponent<Person>().health;
        battleText.text = "";
    }

    /// <summary>
    /// Fights the specified ability number.
    /// </summary>
    /// <param name="ability_Number">The ability number.</param>
    public void Fight(int ability_Number)
    {
        current_Ability_Number = ability_Number;
        StartCoroutine(Wait());
    }

    /// <summary>
    /// Exits the battle.
    /// </summary>
    public void ExitBattle()
    {
        battleCamera.active = false;
        playerCamera.active = true;

        player.GetComponent<Person>().health = 100;
        player.GetComponent<PlayerMovement>().isAllowedToMove = true;
    }

    /// <summary>
    /// Waits this instance.
    /// </summary>
    /// <returns name="BattleActive"> Returns if a battle is happening</returns>
    public IEnumerator Wait()
    {
        bool attackHit;
        bool BattleActive = true;
        attackHit = player.GetComponent<Person>().attack(enemy.GetComponent<Person>(), current_Ability_Number);
        battleText.text = "You used " + player.GetComponent<Person>().getAbilityName() + " on " + enemy.GetComponent<Person>().Name;

        if (!attackHit)
        {
            yield return new WaitForSecondsRealtime(.5f);
            battleText.text += "\nBut it missed...";
        }
        else
        {
            BattleEnemySprite.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSecondsRealtime(.2f);
            BattleEnemySprite.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSecondsRealtime(.2f);
            BattleEnemySprite.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSecondsRealtime(.2f);
            BattleEnemySprite.GetComponent<SpriteRenderer>().enabled = true;
        }

        enemyHealthText.text = enemy.GetComponent<Person>().Name + "\nHP: " + enemy.GetComponent<Person>().health.ToString();

        if (enemy.GetComponent<Person>().health <= 0)
        {
            yield return new WaitForSecondsRealtime(1);
            battleText.text = "VICTORY: Exam Passed!!!";
            yield return new WaitForSecondsRealtime(1);
            battleText.text = "Health increased by 25 HP!";
            yield return new WaitForSecondsRealtime(.75f);
            battleText.text += "Inteligence Increased by 25!";
            yield return new WaitForSecondsRealtime(.75f);
            battleText.text += "Knowledge Increased by 1!";
            yield return new WaitForSecondsRealtime(.75f);
            battleText.text = "Gained 3 Credits";
            yield return new WaitForSecondsRealtime(.75f);
            player.GetComponent<Person>().health += 25;
            player.GetComponent<Person>().attack_Bonus += 5;
            player.GetComponent<Person>().dexterity_Bonus += 1;
            enemy.GetComponent<Person>().defeated = true;
            player.GetComponent<Person>().credits += 3;
            ExitBattle();
        }
        else if (player.GetComponent<Person>().health <= 0)
        {
            yield return new WaitForSecondsRealtime(1);
            battleText.text = "FAILURE: You Have Failed\nGo study and try again later loser";
            yield return new WaitForSecondsRealtime(2);
            ExitBattle();
        }

        if (BattleActive)
        {
            yield return new WaitForSecondsRealtime(2);
            attackHit = enemy.GetComponent<Person>().attack(player.GetComponent<Person>(), 1);
            battleText.text = enemy.GetComponent<Person>().Name + " used " + enemy.GetComponent<Person>().getAbilityName();

            if (!attackHit)
            {
                yield return new WaitForSecondsRealtime(.5f);
                battleText.text += "\nBut it missed...";
            }
            else
            {
                BattlePlayerSprite.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSecondsRealtime(.2f);
                BattlePlayerSprite.GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSecondsRealtime(.2f);
                BattlePlayerSprite.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSecondsRealtime(.2f);
                BattlePlayerSprite.GetComponent<SpriteRenderer>().enabled = true;
            }

            playerHealthText.text = "HP: " + player.GetComponent<Person>().health.ToString();
        }
    }

    /// <summary>
    /// Exits the battle by allowing the player to move again and setting the camera to 
    /// the correct camera that the player was last at.This camera is taken as the parameter
    /// to the method.
    /// </summary>
    /// <param name="Camera">The camera.</param>
    public void ExitBattle(GameObject Camera)
    {
        battleCamera.active = false;
        Camera.active = true;
    }

    /// <summary>
    /// Solids the object hit.
    /// </summary>
    /// <param name="dir">The dir.</param>
    public void SolidObjectHit(Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                player.GetComponent<PlayerMovement>().canMoveNorth = false;
                print("hit North");
                break;
            case Direction.East:
                player.GetComponent<PlayerMovement>().canMoveEast = false;
                print("hit East");
                break;
            case Direction.South:
                player.GetComponent<PlayerMovement>().canMoveSouth = false;
                print("hit South");
                break;
            case Direction.West:
                player.GetComponent<PlayerMovement>().canMoveWest = false;
                print("hit West");
                break;
        }
    }

    /// <summary>
    /// Solids the object left.
    /// </summary>
    public void SolidObjectLeft()
    {
        player.GetComponent<PlayerMovement>().canMoveNorth = true;
        player.GetComponent<PlayerMovement>().canMoveWest = true;
        player.GetComponent<PlayerMovement>().canMoveSouth = true;
        player.GetComponent<PlayerMovement>().canMoveEast = true;
        print("Left");
    }
}
