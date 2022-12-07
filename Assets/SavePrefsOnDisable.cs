using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SavePrefsOnDisable : MonoBehaviour
{

    [SerializeField] private Slider[] slider;
    private void OnEnable()
    {
        LoadVol();
    }
    private void OnDisable()
    {
        SaveVol();
    }

    public void LoadVol()
    {
        SaveManager.instance.LoadSettings();
        SaveManager.instance.LoadVolume("VolumeSoundFX", slider[0]);
        SaveManager.instance.LoadVolume("VolumeMusic", slider[1]);

        slider[2].value = PlayerCharacter.mouseSensitivity;
        Debug.Log("Enable");
    }

    public void SaveVol()
    {
        SaveManager.instance.SaveSettings();
        SaveManager.instance.SaveVolume("VolumeSoundFX", slider[0].value);
        SaveManager.instance.SaveVolume("VolumeMusic", slider[1].value);
        Debug.Log("Disable");
    }

}
