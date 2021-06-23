using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
{

   public RectTransform rectTransformCanvas;
    public RectTransform ThisTransform;

    private void Start()
    {
       
        ThisTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {

       
    }
}
