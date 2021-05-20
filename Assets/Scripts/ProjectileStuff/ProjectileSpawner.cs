using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    private ObjectPooling pooler;

    private void Start()
    {
        pooler = ObjectPooling.instance;
    }
    private void FixedUpdate()
    {
        
    }

    public void OnShoot()
    {
        pooler.SpawnFromPool("NormalBullet", transform.position, Quaternion.identity);
    }
}
