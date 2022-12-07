using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameGrenade : Grenade
{
    [SerializeField] private int damage;
    [SerializeField] private int damageTicks;

    protected override void GrenadeEffect(EnemyBase enemy)
    {
        enemy.GetComponent<Health>().TakeDamage(damage);
        //Create a fuction for the enemy to take burn damage
        enemy.Burn(damageTicks);
    }
}
