using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
         
            Health playerHp = other.GetComponent<PlayerCharacter>().health;
            playerHp.Heal(Amount);
           
            Destroy(gameObject);
        }
    }
}
