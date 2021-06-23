using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private string checkPointName;

    public string CheckPointName { get => checkPointName; set => checkPointName = value; }

    protected CheckpointsSystem checkSystem;

    void Start()
    {
        checkPointName = null;
        checkSystem = CheckpointsSystem.instance;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(checkPointName);
            CheckPointName = this.gameObject.name;
            checkSystem.CheckPoint = this;
           
        }
    }
}
