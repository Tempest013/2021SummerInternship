using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grenade : MonoBehaviour
{
    protected GrenadeSpawner chosenGrenade;

    [SerializeField] protected float boomRadius;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected GameObject particles;

    public Grenade() : base()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        chosenGrenade = GrenadeSpawner.instance;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

  
    protected abstract void GrenadeEffect(EnemyBase enemy);

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            Explosion.Explode(this.gameObject, boomRadius, enemyLayer, GrenadeEffect, particles);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chosenGrenade.GizmoSize);
    }


}
