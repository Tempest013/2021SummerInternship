using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] footStepSFX;
    private AudioSource audioSource;
    bool canTrigger = true;
    float timer = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (canTrigger == false)
            timer += Time.deltaTime;
        if (timer > .5f)
        {
            canTrigger = true;
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player"&&canTrigger)
        {
            canTrigger = false;
            audioSource.PlayOneShot(footStepSFX[Random.Range(0, footStepSFX.Length)]);
        }
    }
}
