using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseManager : MonoBehaviour
{
    #region singleton
    public static CourseManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton

    [Header("Obstacle Course Variables")]
    [SerializeField] private int totalPlatforms;
    [SerializeField] private bool isStarted;
    [SerializeField] private bool isFinished;
    [SerializeField] private bool hasRestarted;

    [Header("Countdown Timer Variables")]
    [SerializeField] private float time = 70f;
    [SerializeField] private TextMeshProUGUI timerText; 

    [Header("Obstacle Course Assets")]
    [SerializeField] private GameObject finalDoor;
    [SerializeField] private int platformCounter;

    [Header("Canvas")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private TextMeshProUGUI platformUICounter;

    private GameObject[] platforms;

    #region refactoring
    public int PlatformCounter { get => platformCounter; set => platformCounter = value; }
    public bool IsStarted { get => isStarted; set => isStarted = value; }
    public bool HasRestarted { get => hasRestarted; set => hasRestarted = value; }
    public bool IsFinished { get => isFinished; set => isFinished = value; }

    #endregion refactoring


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

        //Gets the number of total platforms in the level.
        platforms = GameObject.FindGameObjectsWithTag("ColorChangingPlatform");
        totalPlatforms = platforms.Length;
    }

    // Update is called once per frame
    void Update()
    {
        StartTimeTrial();
        UpdateCounter();
        OpenDoor();
        ResetCounter();
        EndTimeTrial();
    }

    private void UpdateCounter()
    {
        platformUICounter.text = platformCounter.ToString() + "/" + totalPlatforms;
    }

    private void OpenDoor()
    {
        if(platformCounter == totalPlatforms && time > 0)
        {
            finalDoor.SetActive(false);
        }
    }

    private void StartTimeTrial()
    {
        if (isStarted == true)
        {
            canvas.SetActive(true);
            CountdownTimer();
        }
    }

    private void EndTimeTrial()
    {
        if (isFinished == true)
        {
            canvas.SetActive(false);
        }
    }

    private void ResetCounter()
    {
        if(hasRestarted == true)
        {
            platformCounter = 0;
            time = 70.00f;
            canvas.SetActive(false);
        }
    }

    private void CountdownTimer()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            //timerText.text = time.ToString("0");
            DisplayTime(time);
        }
       
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
