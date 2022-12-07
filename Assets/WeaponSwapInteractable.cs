using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSwapInteractable : MonoBehaviour
{
    Button button;
    PlayerCharacter player;
    [SerializeField] int index;
    void Start()
    {
        player = PlayerCharacter.instance;
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.WeaponDictonary[index].unlocked == true)
            button.interactable = true;
        else
            button.interactable = false;
    }
}
