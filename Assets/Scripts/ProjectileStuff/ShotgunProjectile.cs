using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectile : Projectiles
{
    public ShotgunProjectile() : base()
    {
        bulletVelocity = 200f;
        projDamage = 5;
    }

    public override void OnObjectSpawn()
    {
        Vector3 randPoint =
            new Vector3((cam.transform.forward.normalized.x + Random.Range(-0.1f, 0.1f)), (cam.transform.forward.normalized.y + Random.Range(-0.1f, 0.1f)), cam.transform.forward.normalized.z + Random.Range(-0.1f, 0.1f));
        body.velocity = (randPoint * bulletVelocity);
    }
}
