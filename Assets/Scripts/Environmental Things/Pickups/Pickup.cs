using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Visual Aspects")]
    [SerializeField] private float rotationSpeed=.8f;
    [SerializeField] private float bobbingHeight = .0015f;
    [Header("Pickup Values")]
    [SerializeField] private int amount;
    private Vector3 startPosition;
    //TODO MAKE THEM SPIN AND BOBBLE
    private void Start()
    {
        startPosition = transform.position;
    }


    private void Update()
    {
        transform.Rotate(0, rotationSpeed*Time.timeScale, 0);
        transform.position = transform.position + (new Vector3(0, Mathf.Sin(Time.time)*bobbingHeight*Time.timeScale, 0));
    }
    

    public int Amount { get => amount; set => amount = value; }
}
