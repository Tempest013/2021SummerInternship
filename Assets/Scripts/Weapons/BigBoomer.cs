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
            projectileType.SpawnFromPool("BigBoomerBullet", spawner.transform.position, Quaternion.identity);
            Recoil();
            LoseAmmo();
            if (audioClips.Length > 0 &&shotAudioSource!=null)
                shotAudioSource.PlayOneShot(audioClips[0]);
        }
    }
}
