using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorKeys : MonoBehaviour
{
    protected FinalDoor fDoor;

    // Start is called before the first frame update
    void Start()
    {
        fDoor = FinalDoor.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fDoor.KeyCounter += 1;
            this.gameObject.SetActive(false);
        }
    }
}
