using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //TODO MAKE THEM SPIN AND BOBBLE

    private void Update()
    {
        
    }
    [SerializeField]private int amount;

    public int Amount { get => amount; set => amount = value; }
}
