using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip
         slideSFX,
         hornSFX,
         sizzleSFX;
    static AudioSource audioSource;

    private void Awake()
    {
        slideSFX = Resources.Load<AudioClip>("slide");
        sizzleSFX = Resources.Load<AudioClip>("sizzle");
        hornSFX = Resources.Load<AudioClip>("horn");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySFX(string clip)
    {
        // decide on SFX to play when given a string
        switch (clip)
        {
            case "slide":
                audioSource.PlayOneShot(slideSFX);
                break;
            case "sizzle":
                audioSource.PlayOneShot(sizzleSFX);
                break;
            case "horn":
                audioSource.PlayOneShot(hornSFX);
                break;
        }
    }
}
