using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SemiAutomaticWeapon : Weapon
{
    [SerializeField]protected bool recoilFlag;
    [SerializeField]  protected IEnumerator recoilDelay;
    [SerializeField] protected float recoilTime=1f;

   public SemiAutomaticWeapon()
    {  
        recoilDelay = RecoilDelay();
        shotCD = ShotIsOnCD();
    }

    protected IEnumerator RecoilDelay()
    {
        recoilFlag = true;
        yield return new WaitForSeconds(recoilTime);
        recoilFlag = false;
        recoilReset = true;
    }

    protected override void Update()
    {
        if (recoilFlag)
            ApplyRecoil();
        else if(!recoilFlag &&recoilReset)
            RecoilAdjust();
        recoilSmoothing *= 0.9f;
    }

    protected abstract void Fire();

    public override void FirePrimary()
    {
        shotCD = ShotIsOnCD();
        recoilDelay = RecoilDelay();
       if(canShoot)
        {
            Fire();
            StartCoroutine(shotCD);
            StartCoroutine(recoilDelay);
            initialRotation = player.RotationOnX;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(shotCD);
        StopCoroutine(recoilDelay);
        recoilFlag = false;
    }
    public override void FireSecondary()
    {
        throw new System.NotImplementedException();
    }

    public override void StopPrimary()
    {
        throw new System.NotImplementedException();
    }

    public override void StopSecondary()
    {
        throw new System.NotImplementedException();
    }
}
