using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaRifle : AutomaticWeapon
{


    public PlasmaRifle() : base()
    {

        id = 1;
        gunName = "Plasma Rifle";

        maxAmmo = 90;


        canShoot = true;
        FireRate = .1f;

        unlocked = true;


        maxRecoil = new Vector2(1, 5);

        shootingCoroutine = RepeatFire();
    }


    public IEnumerator RepeatFire()
    {
        while (true)
        {
            if (canShoot && currAmmo>0)
            {
                audioSource.PlayOneShot(audioClips[0]);
                projectileType.SpawnFromPool("NormalBullet", spawner.transform.position, Quaternion.identity);
                Recoil();
                LoseAmmo();
            }
            yield return new WaitForSeconds(FireRate);
        }
    }

    public override void StopPrimary()
    {
        if (isShooting)
        {
            //audioSource.Stop();
            if(audioSource.isActiveAndEnabled)
            audioSource.PlayOneShot(audioClips[1]);
        }
        base.StopPrimary();
    }

    public override void FireSecondary()
    {
        throw new System.NotImplementedException();
    }

    public override void StopSecondary()
    {
        throw new System.NotImplementedException();
    }


}
