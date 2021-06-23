using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAssetChanger : MonoBehaviour
{
    //For Training Level
    [SerializeField] private GameObject[] turnOnObjects;
    [SerializeField] private GameObject[] turnOffObjects;


    void Start()
    {
        DeactivateObjects();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for (int i = 0; i < turnOnObjects.Length; i++)
            {
                turnOnObjects[i].SetActive(true);
            }
            for (int i = 0; i < turnOffObjects.Length; i++)
            {
                turnOffObjects[i].SetActive(false);
            }
        }
    }

    private void DeactivateObjects()
    {
        for (int i = 0; i < turnOnObjects.Length; i++)
        {
            turnOnObjects[i].SetActive(false);
        }
      
    }

}
