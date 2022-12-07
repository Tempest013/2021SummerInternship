using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeGrenade : Grenade
{
    [SerializeField] private float freezeTime = 2f;

 

    protected override void GrenadeEffect(EnemyBase enemy)
    {
       
        enemy.Freeze();
    }
}
