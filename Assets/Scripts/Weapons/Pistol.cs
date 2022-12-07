using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : SemiAutomaticWeapon
{

    [SerializeField] private ParticleSystem muzzleFlash;

    public Pistol() : base()
    {
        id = 0;
        gunName = "Pistol";

        maxAmmo = 999999;


        canShoot = true;
        FireRate = 0.3f;

        unlocked = true;



        maxRecoil = new Vector2(1, 5);

    }



    protected override void Fire()
    {
        if (canShoot)
        {
            //audioSource.PlayOneShot(audioClips[0]);
            muzzleFlash.Play();
            projectileType.SpawnFromPool("PistolBullet", spawner.transform.position, Quaternion.identity);
            Recoil();
            if (audioClips.Length > 0 && audioSource != null)
                audioSource.PlayOneShot(audioClips[0]);
        }
    }

    public override void StopPrimary()
    {

    }

}
