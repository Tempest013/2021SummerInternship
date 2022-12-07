using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    private MeshRenderer platformRenderer;

    protected CourseManager courseManager;
    protected FloorBreakerPuzzleManager puzzleManager;

    void Start()
    {
        platformRenderer = this.gameObject.GetComponentInParent<MeshRenderer>();
    }

    void Update()
    {
        courseManager = CourseManager.instance;
        puzzleManager = FloorBreakerPuzzleManager.instance;
        ResetPlatforms();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (platformRenderer.material.color != Color.red && courseManager.HasRestarted == false && puzzleManager.IsFloorBreaker == false)
            {
                platformRenderer.material.color = Color.red;
                courseManager.PlatformCounter += 1;
            }
            else if (puzzleManager.IsFloorBreaker == true)
            {
                platformRenderer.material.color = Color.green;
                puzzleManager.PuzzleCounter += 1;
            }
            
         
        }
    }

    private void ResetPlatforms()
    {
        if(courseManager.HasRestarted == true)
        {
            platformRenderer.material.color = Color.white;
        }
    }
}
