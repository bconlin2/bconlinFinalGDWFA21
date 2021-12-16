using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{
    /*
     * Limits framerate to a targeted constant
     */
    // Start is called before the first frame update
    void Start()
    {
        // turn off vsync
        QualitySettings.vSyncCount = 0;
        // limit fps
        Application.targetFrameRate = 60;
    }
}
