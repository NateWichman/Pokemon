using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 	This Class controls the player movement with the arrowkeys.
 * It also interacts with the SolidObject class through the GameManager class
 * to control whether the player can move through certian objects
 * */
public class PlayerMovement : MonoBehaviour
{
    Animator Anim;

    //Enum: Keeps track of what direction you last moved to determine what sprite to use
    Direction currentDir;

    //Holds the information of what arrow key is being pressed
    Vector2 input;

    //Holds whether the player is currently moving
    bool isMoving = false;

    //Holds the current postion of the player at any given time
    Vector3 startPos;

    //Holds a position in the direction the player wants to move
    Vector3 endPos;

    //Float used for keeping track of time
    float t;

    //Below public variables for the sprites,
    //They will be changed every time the player changes direction
    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    //Public float keeping track of a multiplier for speed. 
    //This way we can tweak how fast the player walks outside of the script
    public float walkSpeed = 3f;

    //Controls whether the player can move at all
    public bool isAllowedToMove = true;

    //Variables to control in what direction the player can move
    public bool canMoveNorth = true;
    public bool canMoveEast = true;
    public bool canMoveSouth = true;
    public bool canMoveWest = true;

    void Start()
    {
        //Instantiating instance variables
        isAllowedToMove = true;
        canMoveNorth = true;
        canMoveEast = true;
        canMoveSouth = true;
        canMoveWest = true;
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && isAllowedToMove)
        {
            //Input now equals the values from the arrowkeys
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0; //Makes it so the player does not move diagnoally
            }
            else
            {
                input.x = 0;
            }

            //The below if statement determins the correct enum to change the sprite
            if (input != Vector2.zero)
            {
                if (input.x < 0)
                {
                    currentDir = Direction.West;
                }
                else if (input.x > 0)
                {
                    currentDir = Direction.East;
                }
                else if (input.y < 0)
                {
                    currentDir = Direction.South;
                }
                else if (input.y > 0)
                {
                    currentDir = Direction.North;
                }

                //Changes sprite based on currentDir value found above
                switch (currentDir)
                {
                    case Direction.North:
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;
                    case Direction.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;
                    case Direction.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;
                    case Direction.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;
                }


                //freezing abilitiy to move if the player is not allowed it move in their intended direction
                if ((input.y > 0) && (!canMoveNorth))
                {
                    isAllowedToMove = false;
                    print("hit North");
                }
                else if ((input.y < 0) && (!canMoveSouth))
                {
                    isAllowedToMove = false;
                    print("hit South");
                }
                else if ((input.x > 0) && (!canMoveEast))
                {
                    isAllowedToMove = false;
                    print("hit East");
                }
                else if ((input.x < 0) && (!canMoveWest))
                {
                    isAllowedToMove = false;
                    print("hit North");
                }

                if (!isMoving && isAllowedToMove)
                {

                    StartCoroutine(Move(transform));
                }
            }
            isAllowedToMove = true;
            /*if (isMoving == true && isAllowedToMove == true)
            {
                if (canMoveNorth == true)
                {
                    Anim.Play("NorthWalk");
                }
                else if (canMoveEast == true)
                {
                    Anim.Play("EastWalk");
                }
                else if (canMoveSouth == true)
                {
                    Anim.Play("SouthWalk");
                }
                else if (canMoveWest == true)
                {
                    Anim.Play("WestWalk");
                }
            }*/
        }
    }

    public IEnumerator Move(Transform entity)
    {
        isMoving = true; //Signalling that the player is moving
        startPos = entity.position; //Putting variable startPos to be the players current position
        t = 0; //Reseting time to 0
        
        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);
        

            while (t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}