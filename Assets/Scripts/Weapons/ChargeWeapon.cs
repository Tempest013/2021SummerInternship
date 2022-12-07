using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChargeWeapon : SemiAutomaticWeapon
{

    [SerializeField] protected bool chargingFlag;
    [SerializeField] protected IEnumerator chargeShot;
    [SerializeField] protected float chargeTime = 0.7f;
    [SerializeField] ParticleSystem chargeUpEffect;
    [SerializeField] ParticleSystem shockWave;
    [SerializeField] AudioClip chargeClip;
    [SerializeField]protected AudioSource shotAudioSource;

    protected IEnumerator ChargeShot()
    {
        chargingFlag = false;
        chargeUpEffect.Play();
        audioSource.Play();
        yield return new WaitForSeconds(chargeTime);
        chargeUpEffect.Stop();
        shockWave.Play();
        chargingFlag = true;
        StopPrimary();
        Fire();
        StartCoroutine(shotCD);
        StartCoroutine(recoilDelay);
       
    }


    public override void FirePrimary()
    {
        chargeShot = ChargeShot();
        shotCD = ShotIsOnCD();
        recoilDelay = RecoilDelay();
        if (canShoot && currAmmo > 0)
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
        chargeUpEffect.Stop();
        audioSource.Stop();
        chargingFlag = false;
    }

    public override void StopSecondary()
    {
        throw new System.NotImplementedException();
    }


}
