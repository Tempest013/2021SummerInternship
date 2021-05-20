using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    private TextMeshProUGUI text;
    public int ammo = 90;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = ammo.ToString();
        PlayerCharacter.OnAmmoLoss += OnAmmoChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
            OnAmmoChange();
    }

    public void OnAmmoChange()
    {
        ammo += -1;
        text.text = ammo.ToString();
    }
}
