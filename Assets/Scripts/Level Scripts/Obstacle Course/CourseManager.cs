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
    }

    private void UpdateCounter()
    {
        platformUICounter.text = platformCounter.ToString() + "/" + totalPlatforms;
    }

    private void OpenDoor()
    {
        if(platformCounter == totalPlatforms)
        {
            finalDoor.SetActive(false);
        }
    }

    private void StartTimeTrial()
    {
        if (isStarted == true)
        {
            canvas.SetActive(true);
        }
    }
}
