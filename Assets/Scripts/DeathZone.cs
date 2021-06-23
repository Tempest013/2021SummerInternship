using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    protected PlayerCharacter player;
    protected CheckpointsSystem checkSystem;


  
    void Start()
    {
          player = PlayerCharacter.instance;
          checkSystem = CheckpointsSystem.instance;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You Died");
            player.transform.position = checkSystem.CheckPoint.transform.position;
            player.transform.rotation = checkSystem.CheckPoint.transform.rotation;

        }
    }
}
