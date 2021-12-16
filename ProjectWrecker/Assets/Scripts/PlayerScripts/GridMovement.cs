using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMovement : MonoBehaviour
{
    #region REFERENCES
    [SerializeField]
    internal PlayerController playerController;
    #endregion

    #region PROPERTIES

    [SerializeField]
    internal Vector3
        direction = Vector3.zero,
        startPosition,
        goalPosition = Vector3.zero;

    [SerializeField]
    internal bool moveCheck;

    [SerializeField]
    internal float snap = 0.005f,
                   rayOffsetX = 0.5f,
                   rayOffsetY = 0.5f,
                   rayOffsetZ = 0.5f;


    #endregion

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerController.gameController.gameOver)
        {
            Movement();
        }
    }

    private void Movement()
    {
        startPosition = playerController.player.transform.position;
        // if the player is not moving
        if (!moveCheck)
        {
            // check directional input

            float horizontal = playerController.playerinput.horizontal;
            float vertical = playerController.playerinput.vertical;

            bool key_w = playerController.playerinput.key_w;
            bool key_a = playerController.playerinput.key_a;
            bool key_s = playerController.playerinput.key_s;
            bool key_d = playerController.playerinput.key_d;

            // check seems to be doing nothing, find a way to handle pressing both directions at the same time
            //if (horizontal != 0)
            // if either but not both are pressed
            if((key_d || key_a) && !(key_d && key_a))
            {
                if (key_d)
                {
                    direction = Vector3.right;
                } // right
                else if (key_a)
                {
                    direction = Vector3.left;
                } // left
                /*// act on horizontal step
                switch (horizontal)
                {
                    case -1:
                        // A
                        direction = Vector3.left;
                        //goalPosition = startPosition + direction * playerController.unit;
                        //moveCheck = true;
                        break;
                    case 1:
                        direction = Vector3.right;
                        //goalPosition = startPosition + direction * playerController.unit;
                        //moveCheck = true;
                        break;
                }*/
               
                // check for walls
                //if (!Physics.Raycast(startPosition, direction, playerController.unit))
                if(CanMove(direction))
                {
                    if (playerController.gameController.menuText.gameObject.activeSelf)
                    {
                        playerController.gameController.menuText.gameObject.SetActive(false);
                    }
                    SoundManager.PlaySFX("slide");
                    goalPosition = startPosition + direction * playerController.unit;
                    moveCheck = true;
                }
            }



            if ((key_w || key_s) && !(key_w && key_s))
            {
                if (key_w)
                {
                    direction = Vector3.forward;
                } // right
                else if (key_s)
                {
                    direction = Vector3.back;
                } // left
                /*// act on horizontal step
                switch (horizontal)
                {
                    case -1:
                        // A
                        direction = Vector3.left;
                        //goalPosition = startPosition + direction * playerController.unit;
                        //moveCheck = true;
                        break;
                    case 1:
                        direction = Vector3.right;
                        //goalPosition = startPosition + direction * playerController.unit;
                        //moveCheck = true;
                        break;
                }*/

                // check for walls
                //if (!Physics.Raycast(startPosition, direction, playerController.unit))
                if (CanMove(direction))
                {
                    if (playerController.gameController.menuText.gameObject.activeSelf)
                    {
                        playerController.gameController.menuText.gameObject.SetActive(false);
                    }
                    SoundManager.PlaySFX("slide");
                    goalPosition = startPosition + direction * playerController.unit;
                    moveCheck = true;
                }
               
            }

        }
        
        
        // if the player has reached their goal
        if (Vector3.Distance(goalPosition, startPosition) > snap && moveCheck)
        {
            //playerController.player.transform.position += playerController.speed * direction * Time.deltaTime;
            playerController.player.transform.position = Vector3.Lerp(startPosition, goalPosition, playerController.speed*Time.deltaTime);
        }
        else
        {
            direction = Vector3.zero;
            goalPosition = startPosition;
            moveCheck = false;
            //StartCoroutine(MovementDelay());
        }
        

    }

    // checks for collisions
    bool CanMove(Vector3 direction)
    {
        // forward/back check
        if(Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction))
        {
            if (Physics.Raycast(startPosition + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, playerController.unit) ||
                Physics.Raycast(startPosition + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, playerController.unit))
            {
                return false;
            }
        }

        // left/right check
        if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
        {
            if (Physics.Raycast(startPosition + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, playerController.unit) ||
                Physics.Raycast(startPosition + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, playerController.unit))
            {
                return false;
            }
        }

        return true;

    }

    IEnumerator MovementDelay()
    {
        yield return new WaitForSeconds(1.0f);
        moveCheck = false;
    }
}