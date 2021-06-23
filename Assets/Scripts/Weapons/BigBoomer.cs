using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomer : ChargeWeapon
{

    public BigBoomer()
    {
        id = 4;
        gunName = "Big Boomer";

        maxAmmo = 90;


        canShoot = true;
        FireRate = 1f;

        unlocked = true;


        maxRecoil = new Vector2(1, 5);
    }


    protected override void Fire()
    {
        if (currAmmo > 0)
        {
            projectileType.SpawnFromPool("RocketBullet", spawner.transform.position, Quaternion.identity);
            Recoil();
            LoseAmmo();
        }
    }
}
