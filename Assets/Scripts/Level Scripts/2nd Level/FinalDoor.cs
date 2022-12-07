using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    #region singleton
    public static FinalDoor instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton


    [SerializeField] private bool keysCollected;
    [SerializeField] private int keyCounter;

    public int KeyCounter { get => keyCounter; set => keyCounter = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (keyCounter == 2)
        {
            this.gameObject.SetActive(false);
        }
    }
}
