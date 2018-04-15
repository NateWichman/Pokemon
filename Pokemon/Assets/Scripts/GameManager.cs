using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject playerCamera;
    public GameObject battleCamera;
    public GameObject libraryCamera1;
    public GameObject titleCamera;
    public GameObject introCamera;

    public GameObject player;
    public GameObject northOfPlayer;
    public GameObject eastOfPlayer;
    public GameObject southOfPlayer;
    public GameObject westOfPlayer;
    public int spaceCounter = 0;
    public int endingIntroLine = 19;

    public bool titleDone = false;
    public bool introDone = false;

    private Vector3 offsetN;
    private Vector3 offsetE;
    private Vector3 offsetS;
    private Vector3 offsetW;

    public GameObject introTextReader;
    

    private Vector3 offsetCamera1;

    public GameObject enemy;

    public Text battleText;
    public Text abilityOneText;
    public Text abilityTwoText;
    public Text abilityThreeText;
    public Text abilityFourText;
    public Text enemyHealthText;
    public Text playerHealthText;
    int current_Ability_Number;
    public GameObject BattleEnemySprite;
    public GameObject BattlePlayerSprite;
 
    


    // Use this for initialization
    void Start()
    {
        titleCamera.SetActive(true);
        introCamera.SetActive(false);
        playerCamera.SetActive(false);
        battleCamera.SetActive(false);
        libraryCamera1.SetActive(false);
        player.GetComponent<PlayerMovement>().isAllowedToMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!titleDone)
        {
            SwitchToIntro();
        }
        if (!introDone)
        {
            SwitchToPlayer();
        }
        //making invisible sprites that detect collisions follow main player
        offsetN = northOfPlayer.transform.position - player.transform.position;
        offsetE = eastOfPlayer.transform.position - player.transform.position;
        offsetS = southOfPlayer.transform.position - player.transform.position;
        offsetW = westOfPlayer.transform.position - player.transform.position;
        //Setting the offset of Camera1 to the correct postition
        offsetCamera1 = playerCamera.transform.position - player.transform.position;

        if(player.GetComponent<Person>().credits == 120)
        {
            //Victory Achieved
        }
        
    }

    void LateUpdate()
    {
        //Making invisible sprites that detect collisions follow main player
        northOfPlayer.transform.position = player.transform.position + offsetN;
        eastOfPlayer.transform.position = player.transform.position + offsetE;
        southOfPlayer.transform.position = player.transform.position + offsetS;
        westOfPlayer.transform.position = player.transform.position + offsetW;
        //Making the camera1 follow player.
        playerCamera.transform.position = player.transform.position + offsetCamera1;
    }
    void SwitchToIntro()
    {

        if (Input.GetKeyDown(KeyCode.Return) && titleDone == false)
        {
            titleDone = true;
            titleCamera.SetActive(false);
            introCamera.SetActive(true);
        }
    }

    void SwitchToPlayer()
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
    
    public void Fight(int ability_Number)
    {
        current_Ability_Number = ability_Number;
        StartCoroutine(Wait());
    }

    public void ExitBattle()
    {
        battleCamera.active = false;
        playerCamera.active = true;

        player.GetComponent<Person>().health = 100;
        player.GetComponent<PlayerMovement>().isAllowedToMove = true;
    }

    IEnumerator Wait()
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
        else if(player.GetComponent<Person>().health <= 0)
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

    /* Exits the battle by allowing the player to move again and setting the camera to 
     * the correct camera that the player was last at. This camera is taken as the parameter
     * to the method.
     * */
    public void ExitBattle(GameObject Camera)
    {
        battleCamera.active = false;
        Camera.active = true;
    }
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
    public void SolidObjectLeft()
    {
        player.GetComponent<PlayerMovement>().canMoveNorth = true;
        player.GetComponent<PlayerMovement>().canMoveWest = true;
        player.GetComponent<PlayerMovement>().canMoveSouth = true;
        player.GetComponent<PlayerMovement>().canMoveEast = true;
        print("Left");
    }
}
