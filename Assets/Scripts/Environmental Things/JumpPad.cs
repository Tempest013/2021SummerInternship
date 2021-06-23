using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float yForce;
    //[SerializeField] private float zSpeed;

    protected PlayerCharacter player;
    private bool isJumping = false;
    
  
    void Start()
    {
        player = PlayerCharacter.instance;
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isJumping == false)
        {
            Debug.Log("JumpPad");
            player.CurrZMovement = yForce;
            isJumping = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && isJumping == true)
        {
            Debug.Log("Exit");
            isJumping = false;
        }
    }

}
