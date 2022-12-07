using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartingLine : MonoBehaviour
{
    protected FloorBreakerPuzzleManager puzzleManager;


    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = FloorBreakerPuzzleManager.instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puzzleManager.IsFloorBreaker = true;
            puzzleManager.StartLevel1 = true;
        }
    }



}
