using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SCRIPT REFERENCES

    [SerializeField]
    internal Playerinput playerinput;
    [SerializeField]
    internal GridMovement gridMovement;

    #endregion

    #region PLAYER PROPERTIES

    [SerializeField]
    internal GameObject player;

    [SerializeField]
    internal GameController gameController;

    [SerializeField]
    internal bool defeat;

    [SerializeField]
    internal float speed = 12.0f;

    [SerializeField]
    internal float unit = 2.0f;

    #endregion

    // player actions go through this script to communicate
    private void Awake()
    {
        player = GameObject.Find("Player");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        playerinput = GetComponent<Playerinput>();
        gridMovement = GetComponent<GridMovement>();
    }
}
