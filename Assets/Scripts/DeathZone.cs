using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    protected PlayerCharacter player;
    protected CheckpointsSystem checkSystem;
    protected CourseManager courseManager;


    void Start()
    {
        player = PlayerCharacter.instance;
        checkSystem = CheckpointsSystem.instance;
        courseManager = CourseManager.instance;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.position = checkSystem.CheckPoint.transform.position;
            player.transform.rotation = checkSystem.CheckPoint.transform.rotation;
            player.StopVelocity();
            if (courseManager != null)
                courseManager.HasRestarted = true;

        }
    }
}
