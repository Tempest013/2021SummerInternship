using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : Projectiles
{
    [SerializeField] private float boomRadius = 100f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject explosion;
    public RocketProjectile() : base()
    {
        bulletVelocity = 50f;
        projDamage = 25;
    }

    public override void OnObjectSpawn()
    {
        body.velocity = ((cam.transform.forward.normalized) * bulletVelocity);
        this.transform.rotation = cam.transform.rotation;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, boomRadius, enemyLayer);
        foreach(Collider hitCollider in hitColliders)
        {
           if(hitCollider.gameObject.tag=="Enemy")
            hitCollider.gameObject.GetComponent<EnemyBase>().health.TakeDamage(projDamage);
        }

        // WILL NEED TO CHANGE THIS TO DELETE THE PARTICLE EFFECTS
        Instantiate(explosion, this.transform.position, Quaternion.identity);

        this.gameObject.SetActive(false);
        //base.OnCollisionEnter(collision);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, boomRadius);
    }
}
