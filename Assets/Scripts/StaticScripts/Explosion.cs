using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Explosion
{
    public delegate void ExplosionEffect(EnemyBase enemy);

    public static void Explode(GameObject gameObject,float boomRadius,LayerMask enemyLayer,ExplosionEffect effect,GameObject particleSystem)
    {
        GameObject explosionParticle= MonoBehaviour.Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity);
        explosionParticle.GetComponentInChildren<ExplosionCollider>().explosionEffect = effect;
        gameObject.SetActive(false);
    }


}
