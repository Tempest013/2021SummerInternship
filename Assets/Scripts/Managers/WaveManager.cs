using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public EnemySpawner currArena;

    public static UnityEvent onEnemyDeath=new UnityEvent();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


    }


    private void Start()
    {
        if (onEnemyDeath != null)
            onEnemyDeath.AddListener(ArenaCheck);
    }
    public void ArenaCheck()
    {
        if (currArena != null && currArena.isActive == true)
            currArena.DeathCheck();
    }



}
