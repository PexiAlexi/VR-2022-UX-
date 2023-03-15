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
    public GameObject objectToDisable2;
    public AudioSource ticksource;
    public AudioClip clipsound;
    public AudioSource alarmsound;
    public AudioClip alarmclip;
    public Animator animator;
    public GameObject partikel;

    private bool isRunning = false;
    private bool stopTimer = false;
    private int minutesStopped = 0;
    private int secondsStopped = 0;

    void Start()
    {
        startButton.onClick.AddListener(StartTimer);
        timeText.color = textColor;
    }

    void Update()
    {
        if (isRunning && !stopTimer)
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
                    objectToDisable2.SetActive(false);
                }
               
                    animator.Play("Porten öppnas");
             

            }

           
        }

        if (stopTimer == true)

        {
            isRunning = false;
            timeText.color = Color.blue;
            ticksource.Stop();
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
            animator.Play("Porten öppnas");
            minutesStopped = Mathf.FloorToInt(timeRemaining / 60);
            secondsStopped = Mathf.FloorToInt(timeRemaining % 60);
            timeRemaining = secondsStopped;
            partikel.SetActive(false);
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

    public void StopTimer()
    {
        stopTimer = true;
    }

    public int GetMinutesStopped()
    {
        return minutesStopped;
    }

    public int GetSecondsStopped()
    {
        return secondsStopped;
    }
}