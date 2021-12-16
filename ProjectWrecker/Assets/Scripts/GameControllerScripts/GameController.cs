using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
    #region SCRIPT REFERENCES
    [SerializeField]
    internal PlayerController playerController;
    #endregion
    #region GAME VARIABLES
    [SerializeField]
    internal bool gameOver,
                  badEnd;

    [SerializeField]
    internal int progress = 0,
                 goal = 6; // game ends after 6 good tiles are touched

    internal GameObject level1,
                        level2,
                        level3,
                        level4,
                        level5,
                        goodTile,
                        goodTile2;

    public TextMeshProUGUI gameOverText1,
                           menuText,
                           victoryText;
    #endregion

    private void Awake()
    {
        // find objects
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        level1 = GameObject.Find("Level1");
        level2 = GameObject.Find("Level2");
        level3 = GameObject.Find("Level3");
        level4 = GameObject.Find("Level4");
        level5 = GameObject.Find("Level5");
        goodTile = GameObject.Find("GoodTile");
        goodTile2 = GameObject.Find("GoodTile2");

        // disable them and only reactivate when needed
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(false);
        level4.SetActive(false);
        level5.SetActive(false);
        goodTile2.SetActive(false);

    }

    // Update is called once per frame
    private void Update()
    {
        // game loop
        gameOver = GameOver();
        if (!gameOver)
        {
            SetLevel();
        }
        
    }

    // decides if the game is over or not
    private bool GameOver()
    {
        if(progress >= goal)
        {
            victoryText.gameObject.SetActive(true);
            return true;
        }
        else if (playerController.defeat)
        {
            gameOverText1.gameObject.SetActive(true);
            badEnd = true;
            return true;
        }
        return false;
    }

    // controls the obstacles and progress
    private void SetLevel()
    {
        switch (progress)
        {
            case 1:
                level1.SetActive(true);
                goodTile2.SetActive(true);
                break;
            case 2:
                level2.SetActive(true);
                goodTile.SetActive(true);
                break;
            case 3:
                level3.SetActive(true);
                goodTile2.SetActive(true);
                break;
            case 4:
                level4.SetActive(true);
                goodTile.SetActive(true);
                break;
            case 5:
                level5.SetActive(true);
                goodTile2.SetActive(true);
                break;
            
        }
    }


}
