using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaRifle : Weapon
{


    public PlasmaRifle():base()
    {

        id = 1;
        name = "Plasma Rifle";

        maxAmmo = 90;
       

        canShoot = true;
        FireRate = .1f;

        unlocked = true;

        recoilRotateX = 0.1f;
        recoilRotateY = 0.1f;
        maxRecoil = new Vector2(1, 5);

        shootingCoroutine = RepeatFire();
    }


    public IEnumerator RepeatFire()
    {
        while (true)
        {
            if (canShoot)
            {
                
                projectileType.SpawnFromPool("NormalBullet", spawner.transform.position, Quaternion.identity);
                Recoil(recoilRotateX, recoilRotateY);
                player.loseAmmo();
            }
            yield return new WaitForSeconds(FireRate);
        }
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
