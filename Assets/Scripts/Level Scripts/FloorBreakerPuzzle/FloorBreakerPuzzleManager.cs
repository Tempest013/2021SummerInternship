using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreakerPuzzleManager : MonoBehaviour
{
    #region singleton
    public static FloorBreakerPuzzleManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton

    [SerializeField] private bool isFloorBreaker;
   

    [Header("Levels")]
    [SerializeField] private GameObject[] levels;

    [SerializeField] private int level1Platforms;
    [SerializeField] private bool startLevel1;

    [SerializeField] private int level2Platforms;
    [SerializeField] private bool startLevel2;

    [SerializeField] private int level3Platforms;
    [SerializeField] private bool startLevel3;

    [SerializeField] private int puzzleCounter;



    #region refactoring
    public bool IsFloorBreaker { get => isFloorBreaker; set => isFloorBreaker = value; }
    public int PuzzleCounter { get => puzzleCounter; set => puzzleCounter = value; }
    public bool StartLevel1 { get => startLevel1; set => startLevel1 = value; }
    public bool StartLevel2 { get => startLevel2; set => startLevel2 = value; }
    public bool StartLevel3 { get => startLevel3; set => startLevel3 = value; }
    public int Level1Platforms { get => level1Platforms; set => level1Platforms = value; }
    public int Level2Platforms { get => level2Platforms; set => level2Platforms = value; }
    public int Level3Platforms { get => level3Platforms; set => level3Platforms = value; }

    #endregion refactoring

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FloorBreaker();
    }

    private void FloorBreaker()
    {
        if (startLevel1 == true && puzzleCounter == Level1Platforms)
        {
            levels[0].SetActive(false);
            puzzleCounter = 0;
            StartLevel2 = true;
            StartLevel1 = false;
        }
        if (startLevel2 == true && puzzleCounter == Level2Platforms)
        {
            levels[1].SetActive(false);
            puzzleCounter = 0;
            StartLevel3 = true;
            StartLevel2 = false;
        }
        if (startLevel3 == true && puzzleCounter == Level3Platforms)
        {
            levels[2].SetActive(false);
            puzzleCounter = 0;
        }
    }
}
