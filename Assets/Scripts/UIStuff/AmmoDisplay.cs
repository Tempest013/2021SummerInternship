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
        ammo = PlayerCharacter.instance.equipedWeapon.currAmmo;
        text.text = ammo.ToString();
        PlayerCharacter.OnAmmoLoss += OnAmmoChange;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnAmmoChange()
    {
        ammo = PlayerCharacter.instance.equipedWeapon.currAmmo;
        text.text = ammo.ToString();
    }
}
