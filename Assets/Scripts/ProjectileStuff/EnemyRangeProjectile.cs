using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeProjectile : Projectiles
{

    public EnemyRangeProjectile() : base()
    {
        bulletVelocity = 100f;
        projDamage = 25;
    }

    public override void OnObjectSpawn()
    {
        Vector3 direction = PlayerCharacter.instance.gameObject.transform.position - this.gameObject.transform.position;
        body.velocity = (direction.normalized * bulletVelocity);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerCharacter.instance.TakeDamage(25);
        }
        this.gameObject.SetActive(false);
    }
}
