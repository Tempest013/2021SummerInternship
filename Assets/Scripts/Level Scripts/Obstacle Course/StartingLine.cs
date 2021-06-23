using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartingLine : MonoBehaviour
{
    protected CourseManager courseManager;
    [SerializeField] private GameObject goText;


    // Start is called before the first frame update
    void Start()
    {
        courseManager = CourseManager.instance;
        TurnOffGoText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            courseManager.IsStarted = true;
            goText.SetActive(true);
            Invoke("TurnOffGoText", 3.0f);
        }
    }

    private void TurnOffGoText()
    {
        goText.SetActive(false);
    }




}
