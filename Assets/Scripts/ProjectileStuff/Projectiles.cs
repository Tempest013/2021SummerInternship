using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour, IPooledObj
{
    public float bulletVelocity;
    protected Camera cam;
    protected Rigidbody body;
    protected int projDamage;

    void Awake()
    {
        body=GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    public abstract void OnObjectSpawn();

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyBase>().health.TakeDamage(projDamage);
        }
        this.gameObject.SetActive(false);
    }

}
