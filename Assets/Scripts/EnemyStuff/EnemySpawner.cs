using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool entered = false;

    [SerializeField] private Wave[] waves;
    private int currWaveIndex = 0;
    public bool isActive = false;
    public int currWaveDeathCount = 0;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject[] pickups;
    private void OnTriggerEnter(Collider other)
    {

        if (entered == false && other.tag == "Player")
        {
            isActive = true;
            foreach (GameObject wall in walls)
                wall.SetActive(true);
            currWaveIndex = 0;
            StartNewWave(0);
            entered = true;
            WaveManager.instance.currArena = this;
            if (pickups.Length > 0)
            {
                foreach (GameObject pickup in pickups)
                    pickup.SetActive(true);
            }
        }
    }

    private void StartNewWave(int index)
    {
        StartCoroutine(waves[index].StartSpawnEnemies());
    }

    public void DeathCheck()
    {
        currWaveDeathCount++;
        if (currWaveDeathCount >= waves[currWaveIndex].enemies.Length)
        {
            if (currWaveIndex + 1 < waves.Length)
            {
                currWaveIndex++;
                StartNewWave(currWaveIndex);
                currWaveDeathCount = 0;
            }
            else
            {
                foreach (GameObject wall in walls)
                {
                    wall.SetActive(false);
                }

            }

        }

    }




}
