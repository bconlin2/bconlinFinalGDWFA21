using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinput : MonoBehaviour
{
    #region REFERENCES
    [SerializeField]
    internal PlayerController playerController;
    #endregion

    [SerializeField]
    internal float 
        horizontal,
        vertical;

    internal bool
        key_ESC,
        key_w,
        key_a,
        key_s,
        key_d,
        key_r;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // might not want to use AxisRaw, causing problems when pressing both directions (per axis) at the same time
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // respective WASD controls
        key_w = Input.GetKeyDown(KeyCode.W);
        key_a = Input.GetKeyDown(KeyCode.A);
        key_s = Input.GetKeyDown(KeyCode.S);
        key_d = Input.GetKeyDown(KeyCode.D);

        key_r = Input.GetKeyDown(KeyCode.R);
        key_ESC = Input.GetKeyDown(KeyCode.Escape);
    }
}
