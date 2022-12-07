using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : SemiAutomaticWeapon
{

    //private float fireRange = 50f;
    private static int pellets = 20;
    [SerializeField] private ParticleSystem muzzleFlash;
    //private LineRenderer[] bulletTracer = new LineRenderer[pellets];
    //private float timer = 0.5f;
    //private bool hasFired = false;


    public Shotgun()
    {
        
        id = 2;
        gunName = "Shotgun";

        maxAmmo = 90;


        canShoot = true;
        FireRate = 1f;

        unlocked = true;


        maxRecoil = new Vector2(1, 5);

       

    }
    protected override void Update()
    {
     
        base.Update();
    }

    protected override void Fire()
    {
        if (currAmmo > 0)
        {
            audioSource.PlayOneShot(audioClips[0]);
            muzzleFlash.Play();
            for (int i = 0; i < pellets; i++)
            {
                projectileType.SpawnFromPool("ShotgunBullet", spawner.transform.position, Quaternion.identity);
            }
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

}
