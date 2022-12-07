using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] public string name;
    [SerializeField] public GameObject[] enemies;
    public bool isComplete = false;

    [SerializeField] private float[] spawnTimers;

    public IEnumerator StartSpawnEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (spawnTimers.Length>0)
            {
                if (i < spawnTimers.Length)
                {
                    yield return new WaitForSeconds(spawnTimers[i]);
                }
                else
                {
                    yield return new WaitForSeconds(spawnTimers[spawnTimers.Length - 1]);
                }
            }
            enemies[i].SetActive(true);
        }
    }
}
