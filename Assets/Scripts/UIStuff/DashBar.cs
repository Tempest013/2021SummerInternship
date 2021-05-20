using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    private PlayerCharacter player;
    private Slider slider;

    private void Start()
    {
        player = PlayerCharacter.instance;
        player.Dashbar = this;
        PlayerCharacter.OnDasher += turnOnObject;
        PlayerCharacter.OnDasher += StartDashCoolDown;
        slider = GetComponent<Slider>();
        slider.maxValue = 2f;
        slider.value = 0f;
        this.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void turnOnObject()
    {
        this.gameObject.SetActive(true);
    }

    public void StartDashCoolDown()
    {
        slider.value = 0f;
        StartCoroutine(AnimateDashBar());
    }

    IEnumerator AnimateDashBar()
    {
        float sec = PlayerCharacter.instance.DashCooldown;
        float animTime = 0f;
        while (animTime < sec)
        {
            animTime += Time.deltaTime;
            float lerpValue = animTime / sec;
            slider.value = Mathf.Lerp(0, 2, lerpValue);
            yield return null;
        }
        this.gameObject.SetActive(false);
    }
}
