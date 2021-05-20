using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup :Pickup
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            ArmorUI playerHp = other.GetComponent<PlayerCharacter>().armor;
            playerHp.HealArmor(Amount);
            Destroy(gameObject);
        }
    }
}
