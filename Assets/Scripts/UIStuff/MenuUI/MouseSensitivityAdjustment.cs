using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseSensitivityAdjustment : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void SetMouseSensitivity(Slider slider)
    {
        PlayerCharacter.mouseSensitivity = slider.value;
        PlayerCharacter.mouseSensitivity=slider.value;
    }

}
