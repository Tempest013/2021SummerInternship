using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{

  

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Invoke("Restore", 5);
        }
    }

    private void Restore()
    {
        this.gameObject.SetActive(true);
    }

   
}
