using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float yForce;
    //[SerializeField] private float zSpeed;

    protected PlayerCharacter player;
    //[SerializeField]  private Rigidbody playerBody;
  


    // Start is called before the first frame update
    void Start()
    {
        player = PlayerCharacter.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           // other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * yForce);

 
            Debug.Log("Jump");
            player.CurrZMovement = yForce;
        }
    }

}
