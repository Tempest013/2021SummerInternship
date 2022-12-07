using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VolumeAdjustment : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private AudioMixer mixer;
    private Slider slider;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
    }

    public void SetVolume(string exposedParam)
    {
        if(slider != null)
        {
            mixer.SetFloat(exposedParam, slider.value);
        }
        
        //save volume (string, float);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        audio.Play();
    }
}
