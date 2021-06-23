using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : SemiAutomaticWeapon
{

    public RocketLauncher() : base()
    {
        id = 3;
        gunName = "Rocket Launcher";

        maxAmmo = 90;


        canShoot = true;
        FireRate = 1f;

        unlocked = true;



        maxRecoil = new Vector2(1, 5);


    }
  
    protected override void Fire()
    {
        
            if (canShoot && currAmmo>0)
            {
                audioSource.PlayOneShot(audioClips[0]);
                projectileType.SpawnFromPool("RocketBullet", spawner.transform.position, Quaternion.identity);
                Recoil();
                LoseAmmo();
               

            }
        
    }
    public override void StopPrimary()
    {

    }
    public override void FireSecondary()
    {
        throw new System.NotImplementedException();
    }


    public override void StopSecondary()
    {
        throw new System.NotImplementedException();
    }

    protected override void Update()
    {
        base.Update();
    }
}
