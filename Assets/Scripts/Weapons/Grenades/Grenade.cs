using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    protected GrenadeSpawner chosenGrenade;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Test")
        {
          if (chosenGrenade.NormalGrenade == true)
          {
            Debug.Log("Blast");
            Destroy(other.gameObject);
          }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chosenGrenade.GizmoSize);
     
    }


}
