using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingWalls : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material blueMat;
    [SerializeField] private Material greenMat;
    [SerializeField] private Material redMat;

    [Header("Times (Have to be the same [4secs or more])")]
    [SerializeField] private float offTime;
    [SerializeField] private float repeatTime;


    // Start is called before the first frame update
    void Start()
    {
       // Disappear();
        InvokeRepeating("Disappear", 0.0f, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("Disappear", 7.0f, 8.0f);
    }

    private void ChangeToBlue()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = blueMat;
    }

    private void ChangeToGreen()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = greenMat;
    }

    private void ChangeToRed()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = redMat;
    }

    private void TurnOffWall()
    {
        this.gameObject.SetActive(false);
    }

    private void TurnOnWall()
    {
        this.gameObject.SetActive(true);
    }

    private void Disappear()
    {
        Invoke("ChangeToBlue", 1.0f);
        Invoke("ChangeToGreen", 2.0f);
        Invoke("TurnOffWall", 3.0f);
        Invoke("ChangeToRed", 4.0f);
        Invoke("TurnOnWall", offTime);
      
    }
}
