using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{

    #region REFERENCES
    [SerializeField]
    internal PlayerController playerController;
    #endregion

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    
    void Update()
    {
        bool key_r = playerController.playerinput.key_r;

        // reset
        if (key_r && playerController.gameController.gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
