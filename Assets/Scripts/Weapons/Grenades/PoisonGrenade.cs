using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGrenade :Grenade
{
    [SerializeField] float slowAmount;
    [SerializeField] int damageTicks;
   

    protected override void GrenadeEffect(EnemyBase enemy)
    {
       //todo
       //A function that will cause enemies to take a dot
       enemy.Poison(damageTicks);
    }
}
