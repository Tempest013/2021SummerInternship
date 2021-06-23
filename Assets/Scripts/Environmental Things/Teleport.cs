using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
  
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private float teleportDelay;

    private PlayerCharacter player;

    void Start()
    {
        player = PlayerCharacter.instance;
    }

  
    
    

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Teleporting(teleportDelay));
        }
    }


    IEnumerator Teleporting( float delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = spawnPoint.transform.position;
    }

    

    

}
