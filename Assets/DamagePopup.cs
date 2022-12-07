using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{

    TextMeshPro tmPro;

    
    public static void Create(Vector3 pos,int damage,GameObject dmgPopup)
    {
        GameObject transformDamagePopup = Instantiate(dmgPopup, pos, Quaternion.identity);
        DamagePopup damagepopup = transformDamagePopup.GetComponent<DamagePopup>();
        damagepopup.changeText(damage);

    }


    private void Awake()
    {
        tmPro = GetComponent<TextMeshPro>();
    }


    public void changeText(int damage)
    {
        tmPro.text = damage.ToString();
    }
   
}
