using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNexLevel : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    private BoxCollider collider;
  
    void Start()
    {
        collider = GetComponent<BoxCollider>();
   

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {


            SceneManagement.instance.loadNextScene(nextSceneName);
        }
    }
}
