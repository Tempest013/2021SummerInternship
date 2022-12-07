using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            Health playerHp = other.GetComponent<PlayerCharacter>().Health;
            if (playerHp.hp != playerHp.maxHp)
            {
                PlaySoundFX(other.GetComponent<PlayerCharacter>(), 0, 1);
                player.PickupAudioSource.Play();
                playerHp.Heal(Amount);
                Destroy(gameObject);
            }
        }
    }
}
