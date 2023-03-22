using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playclicksound : MonoBehaviour
{
    public AudioSource audioSource; // Assign the audio source in the Inspector
    public AudioClip soundClip; // Assign the sound clip in the Inspector

    public void PlaySound()
    {
        audioSource.PlayOneShot(soundClip); // Play the sound clip once
    }
}
