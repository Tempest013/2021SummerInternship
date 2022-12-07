using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FullscreenToggle : MonoBehaviour
{
    private Toggle toggle;
   public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
   
    private void OnEnable()
    {
        
        toggle = GetComponent<Toggle>();
        if(toggle!=null)
        toggle.isOn = (Screen.fullScreen == true) ? true : false;

    }
}
