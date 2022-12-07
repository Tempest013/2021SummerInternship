using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
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
            SaveManager.instance.Save();
            CheckPointName = this.gameObject.name;
            checkSystem.CheckPoint = this;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
