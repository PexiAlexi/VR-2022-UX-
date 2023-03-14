using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Triggerpoint : MonoBehaviour
{
    public GameObject[] items;
    public TextMeshProUGUI scoreText;
    public GameObject mattan;

    private int score = 0;

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
                scoreText.text = "Bollar: " + score;

                break;
            }

            if (score == 5)
            {

                mattan.SetActive(true);
            }
        }
    }
}
