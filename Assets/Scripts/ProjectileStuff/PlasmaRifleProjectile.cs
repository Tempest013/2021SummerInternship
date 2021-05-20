using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaRifleProjectile : Projectiles
{

    public PlasmaRifleProjectile() : base()
    {
        bulletVelocity = 75f;
        projDamage = 3;
    }

    public override void OnObjectSpawn()
    {
        body.velocity = ((cam.transform.forward.normalized) * bulletVelocity);
        this.transform.rotation = cam.transform.rotation;
    }

}
