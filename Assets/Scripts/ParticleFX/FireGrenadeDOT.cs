using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrenadeDOT : MonoBehaviour
{
    [SerializeField] private int damage=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBase>().Burn(damage);
        }
    }

}
