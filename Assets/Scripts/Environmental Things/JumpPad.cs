using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float yForce;
    private PlayerCharacter player;
    private bool isJumping = false;
    
  
    void Start()
    {
        player = PlayerCharacter.instance;
    }

   
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.CurrZMovement = yForce;
            isJumping = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isJumping == true)
        {
            isJumping = false;
        }
    }

}
