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
        {
            Destroy(CheckpointsSystem.instance.gameObject);
            instance = this;
        }
    }
    #endregion singleton

    [Header("CheckPoints")]
    [SerializeField] private CheckPoint[] checkPoints;
    [SerializeField] private GameObject[] checkPointVisuals;
    [SerializeField] private GameObject[] respawnPoints;

    private int indexActivator = -1;
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
        if (SceneManagement.instance != null)
        {
            if (SceneManagement.instance.checkPoint != -2)
            {
                if(indexActivator >= 0 && indexActivator < checkPoints.Length)
                {
                    this.indexActivator = SceneManagement.instance.checkPoint;
                    checkPoint = checkPoints[indexActivator];
                }
                
            }
            if (IndexActivator == -1)
            {
                checkPoint = checkPoints[0];
            }
        }
        else
        {
            checkPoint = checkPoints[0];
            indexActivator = 0;
        }
        player.transform.position = checkPoint.transform.position;
        player.transform.rotation = checkPoint.transform.rotation;
    }

    private void OnEnable()
    {
        if (checkPoints[0] != null)
        {
            checkPoint = checkPoints[0];
            if (player != null)
            {
                player.transform.position = checkPoint.transform.position;
                player.transform.rotation = checkPoint.transform.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIndex();
        ActivateCheckPoint();
        DeactivateVisuals();

    }

    public void DeactivateVisuals()
    {
        for (int i = 0; i < checkPointVisuals.Length; i++)
        {
            if (CheckPoint.CheckPointName != checkPoints[i].name)
            {
                checkPointVisuals[i].SetActive(false);
            }
        }
    }

    public void ActivateCheckPoint()
    {
        if( indexActivator >= 0 && indexActivator < checkPoints.Length)
        {
            CheckPoint = checkPoints[indexActivator];
            checkPointVisuals[indexActivator].SetActive(true);
        }


    }

    private void CheckIndex()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            if (checkPoint != null)
            {
                if (CheckPoint.CheckPointName == checkPoints[i].name)
                {
                    indexActivator = i;

                }
            }
        }
    }
}
