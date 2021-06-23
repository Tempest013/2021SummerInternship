using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChargeWeapon : SemiAutomaticWeapon
{

    [SerializeField] protected bool chargingFlag;
    [SerializeField] protected IEnumerator chargeShot;
    [SerializeField] protected float chargeTime = 0.7f;



    protected IEnumerator ChargeShot()
    {
        chargingFlag = false;
        yield return new WaitForSeconds(chargeTime);
        chargingFlag = true;
        Fire();
        StartCoroutine(shotCD);
        StartCoroutine(recoilDelay);
    }


    public override void FirePrimary()
    {
        chargeShot = ChargeShot();
        shotCD = ShotIsOnCD();
        recoilDelay = RecoilDelay();
        if (canShoot)
        {
            StartCoroutine(chargeShot);
        }
    }

    public override void FireSecondary()
    {
        throw new System.NotImplementedException();
    }

    public override void StopPrimary()
    {
        if(chargeShot!=null)
        StopCoroutine(chargeShot);
        chargingFlag = false;
    }

    public override void StopSecondary()
    {
        throw new System.NotImplementedException();
    }


}
