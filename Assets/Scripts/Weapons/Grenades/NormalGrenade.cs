using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGrenade : Grenade
{
    [SerializeField] private float fuseTime = 1.5f;
    [SerializeField] private int damage = 10;
   
    private IEnumerator StartFuse()
    {
        yield return new WaitForSeconds(fuseTime);
        Explosion.Explode(this.gameObject,boomRadius,enemyLayer,GrenadeEffect,particles);
       
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(StartFuse());
    }

    protected override void GrenadeEffect(EnemyBase enemy)
    {
        enemy.GetComponent<Health>().TakeDamage(damage);
    }
}
