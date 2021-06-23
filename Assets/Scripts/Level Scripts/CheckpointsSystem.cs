using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsSystem : MonoBehaviour
{
    #region singleton
    public static CheckpointsSystem instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton

    [Header("CheckPoints")]
    [SerializeField] private CheckPoint[] checkPoints;
    [SerializeField] private GameObject[] checkPointVisuals;
    [SerializeField] private GameObject[] respawnPoints;

    private int indexActivator;
    protected PlayerCharacter player;


    private CheckPoint checkPoint;

    #region Refactoring
    public int IndexActivator { get => indexActivator; set => indexActivator = value; }
    public CheckPoint CheckPoint { get => checkPoint; set => checkPoint = value; }

    #endregion Refactoring

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerCharacter.instance;             
    }

    // Update is called once per frame
    void Update()
    {
        CheckIndex();
        ActivateCheckPoint(indexActivator);
        DeactivateVisuals();

    }

    private void DeactivateVisuals()
    {
        for (int i = 0; i < checkPointVisuals.Length; i++)
        {                    
            if (CheckPoint.CheckPointName != checkPoints[i].name)
            {
                checkPointVisuals[i].SetActive(false);
            }
        }
    }

    private void ActivateCheckPoint(int indexActive)
    {
        CheckPoint = checkPoints[indexActive];
        checkPointVisuals[indexActive].SetActive(true);

    }

    private void CheckIndex()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
          if(checkPoint != null)
          {
             if (CheckPoint.CheckPointName == checkPoints[i].name)
             {
                indexActivator = i;
             
             }
          }        
        }
    }    
}
