using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    protected CourseManager courseManager;
  
    // Start is called before the first frame update
    void Start()
    {
        courseManager = CourseManager.instance;
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            courseManager.IsFinished = true;
        }
    }




}
