using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    private Slider slider;
    private float iFrameSec;
    private IEnumerator healthAnimator;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHp;
        slider.value = hp;

        PlayerCharacter.instance.Health = this;
        iFrameSec = PlayerCharacter.instance.IFrameDuration;
    }

    void Update()
    {
      

    }

    public override void Heal(int amount)
    {
        base.Heal(amount);
        if (healthAnimator != null)
            StopCoroutine(healthAnimator);
        healthAnimator = AnimateHealthBar(iFrameSec);
        StartCoroutine(healthAnimator);

    }
    public override void TakeDamage(int damage)
    {
        hp -= damage;
        if (healthAnimator != null)
            StopCoroutine(healthAnimator);
        healthAnimator = AnimateHealthBar(iFrameSec);
        StartCoroutine(healthAnimator);
    }

    public void SetHealthBar(int amount)
    {
        slider.value = amount;
    }

    public IEnumerator AnimateHealthBar(float sec)
    {
        float animTime = 0f;
        while (animTime < sec)
        {
            animTime += Time.deltaTime;
            float lerpValue = animTime / sec;
            slider.value = Mathf.Lerp(slider.value, hp, lerpValue);
            yield return null;
        }
    }
}
