using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //private bool onPlatform;


    protected PlayerCharacter player;


    void Start()
    {
        player = PlayerCharacter.instance;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //onPlatform = true;
            other.transform.SetParent(transform); 
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //onPlatform = false;
            other.transform.SetParent(null);
        }
    }
}

