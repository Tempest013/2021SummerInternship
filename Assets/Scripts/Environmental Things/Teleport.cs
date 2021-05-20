using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Teleport");
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Teleporting(collision, 2));
        }
    }

    IEnumerator Teleporting(Collision collision, float delay)
    {
        yield return new WaitForSeconds(delay);
        collision.transform.position = spawnPoint.transform.position;
    }

    

    

}
