using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionDropDown : MonoBehaviour
{
    
    public void ChangeResolution(int index)
    {
        
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(960, 540, Screen.fullScreen);
                break;
        }
    }


}
