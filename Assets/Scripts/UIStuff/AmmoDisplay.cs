using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int ammo;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        PlayerCharacter.OnAmmoLoss += OnAmmoChange;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        ammo = PlayerCharacter.instance.equipedWeapon.currAmmo;
        if (ammo == 9999)
            text.text = "∞";
        else
            text.text = ammo.ToString();
    }

    public void OnAmmoChange()
    {
        if(PlayerCharacter.instance.equipedWeapon!=null)
        ammo = PlayerCharacter.instance.equipedWeapon.currAmmo;
        text.text = ammo.ToString();
    }
}
