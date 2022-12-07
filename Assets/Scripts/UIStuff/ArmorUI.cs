using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour
{
    public int armor;
    public int maxArmor;
    private float iFrameSec;
    private IEnumerator armorAnimator;
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxArmor;
        slider.value = armor;
        iFrameSec = PlayerCharacter.instance.IFrameDuration;
        armorAnimator = AnimateArmorBar(iFrameSec);

        PlayerCharacter.instance.armor = this;
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
            TakeDamage(12);
    }
    public void HealArmor(int amount)
    {
        armor += amount;
        if (armor > maxArmor)
            armor = maxArmor;
        if (armorAnimator != null)
            StopCoroutine(armorAnimator);
        armorAnimator = AnimateArmorBar(iFrameSec);
        StartCoroutine(armorAnimator);
    }
    public void TakeDamage(int damage)
    {
        armor -= damage;
        if (armorAnimator != null)
            StopCoroutine(armorAnimator);
        armorAnimator = AnimateArmorBar(iFrameSec);
        StartCoroutine(armorAnimator);
    }

    public void SetArmorBar(int amount)
    {
        slider.value = amount;
    }

    IEnumerator AnimateArmorBar(float sec)
    {
        float animTime = 0f;
        while (animTime < sec)
        {
            animTime += Time.deltaTime;
            float lerpValue = animTime / sec;
            slider.value = Mathf.Lerp(slider.value, armor, lerpValue);
            yield return null;
        }
    }
}
