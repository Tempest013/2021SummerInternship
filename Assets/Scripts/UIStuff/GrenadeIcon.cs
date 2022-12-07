using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GrenadeIcon : MonoBehaviour
{

    private Image sprite;
    [SerializeField] private Image haloImage;

    private float timeElapsed;
    private float grenadeCD;

    void Start()
    {
        sprite = GetComponent<Image>();
        if (GrenadeSpawner.onChangeGrenade != null)
            GrenadeSpawner.onChangeGrenade.AddListener(ChangeColor);
        if (GrenadeSpawner.onThrowGrenade != null)
            GrenadeSpawner.onThrowGrenade.AddListener(StartFillAmount);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeColor(Color color)
    {
        sprite.color = color;
    }
    private void StartFillAmount(float time)
    {
        grenadeCD = time;
        StartCoroutine(FillBar(time));
    }
    private IEnumerator FillBar(float grenadeCD)
    {
        timeElapsed = 0;
        while (timeElapsed<grenadeCD)
        {
            timeElapsed += Time.deltaTime;
            haloImage.fillAmount= timeElapsed / grenadeCD;
            yield return null;

        }

    }
}
