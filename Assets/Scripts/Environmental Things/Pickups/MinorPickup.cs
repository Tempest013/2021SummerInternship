using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorPickup : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody body;
    protected int jumpvalue = 250;
    protected float deathTimer = 4f;
    [SerializeField]  protected int amount = 5;

   public virtual void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(Random.Range(-jumpvalue,jumpvalue), Random.Range(-jumpvalue, jumpvalue), Random.Range(-jumpvalue, jumpvalue)));
        StartCoroutine(StartDeath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void PlaySoundFX(PlayerCharacter character, float index, float volume)
    {
        character.PickupAudioSource.volume = volume;
        character.PickupAudioSource.PlayOneShot(character.PickupAudioClips[0]);
    }
    public IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}
