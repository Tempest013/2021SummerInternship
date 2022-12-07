using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollider : MonoBehaviour
{
   

    public Explosion.ExplosionEffect explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" &&explosionEffect!=null)
            explosionEffect(other.GetComponent<EnemyBase>());
    }
}
