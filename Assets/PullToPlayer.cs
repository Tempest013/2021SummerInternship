using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullToPlayer : MonoBehaviour
{

    GameObject parentObject;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float pullSpeed;
    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius, layer);
        foreach(Collider collider in colliders)
        {
            if(collider.gameObject.tag=="Player")
            {
                    gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,
                    new Vector3(collider.gameObject.transform.position.x,collider.gameObject.transform.position.y+1f,collider.gameObject.transform.position.z), pullSpeed);
            }
        }

    }
}
