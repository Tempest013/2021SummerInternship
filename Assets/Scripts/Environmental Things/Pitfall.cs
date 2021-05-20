using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("poop");
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
