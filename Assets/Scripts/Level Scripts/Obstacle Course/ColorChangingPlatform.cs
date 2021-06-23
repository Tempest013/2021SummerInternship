using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    private MeshRenderer platformRenderer;

    protected CourseManager courseManager;

    // Start is called before the first frame update
    void Start()
    {
        platformRenderer = this.gameObject.GetComponentInParent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        courseManager = CourseManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (platformRenderer.material.color != Color.red)
            {
                Debug.Log("ColorChange");
                platformRenderer.material.color = Color.red;
                courseManager.PlatformCounter += 1;
            }
         
        }
    }
}
