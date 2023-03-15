using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Triggerpoint : MonoBehaviour
{
    public GameObject[] items;
    public TextMeshProUGUI scoreText;
    public GameObject mattan;
    public GameObject poängarenav;
    public GameObject partikel;
    public GameObject partikel2;
    public AudioSource pointmusic;
    public AudioClip clipwinmusic;
    public Timer stoptime;
    public float particleDuration = 5.0f; // duration in seconds for the particle effect

    private int score = 0;
    private float particleTimer = 0.0f;
    private bool particleActive = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger zone is one of the items in the array
        for (int i = 0; i < items.Length; i++)
        {
            if (other.gameObject == items[i])
            {
                // Deactivate the item
                items[i].SetActive(false);

                // Increment the score and update the score text
                score++;
                Debug.Log(score);
                scoreText.text = "Bollar: " + score;
                pointmusic.PlayOneShot(clipwinmusic);
                partikel.SetActive(true);
                particleActive = true;
                particleTimer = 0.0f;

                break;
            }

            if (score == 4)
            {

                mattan.SetActive(true);
                stoptime.StopTimer();
                poängarenav.SetActive(false);
            }

        }
    }


    private void Update()
    {
        // If the particle effect is active, check if the duration has elapsed
        if (particleActive)
        {
            particleTimer += Time.deltaTime;
            if (particleTimer >= particleDuration)
            {
                // Deactivate the particle effect
                partikel.SetActive(false);
                particleActive = false;
            }
        }
    }
}
