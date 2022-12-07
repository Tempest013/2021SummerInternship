using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : AmmoPickup
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlaySoundFX(other.GetComponent<PlayerCharacter>(), 0, 1);
            Weapon weapon;
            weapon = other.GetComponent<PlayerCharacter>().WeaponDictonary[weaponId];
            weapon.unlocked = true;
            weapon.currAmmo += Amount;
            if (weapon.currAmmo > weapon.maxAmmo)
                weapon.currAmmo = weapon.maxAmmo;

            Destroy(gameObject);
        }
    }

}
