using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorHealthPickup : MinorPickup
{
    // Start is called before the first frame update
   public override void Start()
    {
        base.Start();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlaySoundFX(other.GetComponent<PlayerCharacter>(), 0, 1);
            other.gameObject.GetComponent<PlayerCharacter>().Health.Heal(amount);
            Destroy(this.gameObject);  
        }
    }

}
