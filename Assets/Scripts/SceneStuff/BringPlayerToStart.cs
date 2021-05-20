using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringPlayerToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacter.instance.transform.position = this.gameObject.transform.position;

    }
     private IEnumerator BringPlayer()
     {
        yield return new WaitForSeconds(10f);
        PlayerCharacter.instance.transform.position = this.gameObject.transform.position;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
