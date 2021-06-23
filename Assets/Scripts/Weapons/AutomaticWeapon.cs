using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon :Weapon
{

    protected IEnumerator shootingCoroutine;



    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        ApplyRecoil();
        if (!IsShooting && recoilReset)
            RecoilAdjust();
        recoilSmoothing *= 0.9f;
    }

   

  

    public override void FirePrimary()
    {
        if (canShoot &&currAmmo>0)
        {
            StartCoroutine(shootingCoroutine);
            IsShooting = true;
            StartCoroutine(ShotIsOnCD());    
        }
        
    }



    public override void FireSecondary() { }
    public override void StopPrimary()
    {
        if (IsShooting == true)
        {
          
            IsShooting = false;
            if (shootingCoroutine != null)
                StopCoroutine(shootingCoroutine);
            if (CheckRecoilReset())
            {
                recoilReset = true;
               
                initialRotation = player.RotationOnX + currRecoil.y;
            }
        }
    }
    public override void StopSecondary() { }
    protected override IEnumerator ShotIsOnCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;
    }

    public AutomaticWeapon()
    {
        //projectileType = ObjectPooling.instance;
    }
  

}
