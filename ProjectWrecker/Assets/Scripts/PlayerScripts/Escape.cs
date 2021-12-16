using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
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
        bool key_ESC = playerController.playerinput.key_ESC;

        // end game
        if (key_ESC)
        {
            Application.Quit();
        }
    }
}
