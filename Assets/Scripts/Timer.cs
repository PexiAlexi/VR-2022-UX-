using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120.0f; // 2 minutes in seconds
    public Text timeText;
    public Button startButton;
    public Color textColor = Color.white;
    public Color timeoutColor = Color.red;
    public GameObject objectToDisable;
    public AudioSource ticksource;
    public AudioClip clipsound;
    public AudioSource alarmsound;
    public AudioClip alarmclip;
    public Animator animator;

    private bool isRunning = false;

    void Start()
    {
        startButton.onClick.AddListener(StartTimer);
        timeText.color = textColor;
    }

    void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;

            UpdateTimeText();
            if (timeRemaining <= 0)
            {
                isRunning = false;
                timeRemaining = 0;
                timeText.color = timeoutColor;
                ticksource.Stop();
                alarmsound.PlayOneShot(alarmclip);
                if (objectToDisable != null)
                {
                    objectToDisable.SetActive(false);
                }
               
                    animator.Play("Porten öppnas");
             

            }
        }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void StartTimer()
    {
        isRunning = true;
        startButton.gameObject.SetActive(false);
        ticksource.Play();

    }
}