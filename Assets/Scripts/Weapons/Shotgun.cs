using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    //private float fireRange = 50f;
    private static int pellets = 20;
    //private LineRenderer[] bulletTracer = new LineRenderer[pellets];
    //private float timer = 0.5f;
    //private bool hasFired = false;


    public Shotgun() : base()
    {

        id = 2;
        name = "Shotgun";

        maxAmmo = 90;
       

        canShoot = true;
        FireRate = 1f;

        unlocked = true;

        recoilRotateX = 0.1f;
        recoilRotateY = 0.7f;
        maxRecoil = new Vector2(1, 5);

        shootingCoroutine = RepeatFire();
    }
    protected override void Recoil(float recoilX, float recoilY)
    {
        recoilSmoothing.x = Random.Range(-recoilX, recoilX);
        recoilSmoothing.y = recoilY;
    }
    public IEnumerator RepeatFire()
    {
        while (true)
        {
            if (canShoot)
            {

                //for (int i = 0; i < pellets; i++)
                //{

                //    RaycastHit hit;
                //    Vector2[] points = new Vector2[pellets];
                //    points[i] = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
                //    if (Physics.Raycast(spawner.transform.position, new Vector3(points[i].x, points[i].y, -fireRange), out hit, fireRange))
                //    {
                //        hasFired = true;
                //        bulletTracer[i].enabled = true;
                //        bulletTracer[i].positionCount = 2;
                //        Vector3[] linePoints = new Vector3[2];
                //        linePoints[0] = spawner.transform.position;
                //        linePoints[1] = new Vector3(points[i].x, points[i].y, -fireRange);
                //        bulletTracer[i].SetPositions(linePoints);
                //        Debug.Log(hit.distance);
                //        if (hasFired)
                //        {
                //            bulletTracer[i].enabled = false;
                //            timer = 0.5f;
                //            hasFired = false;
                //        }
                //    }
                //}


                for (int i = 0; i < pellets; i++)
                {
                    projectileType.SpawnFromPool("ShotgunBullet", spawner.transform.position, Quaternion.identity);
                }
                Recoil(recoilRotateX, recoilRotateY);
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
