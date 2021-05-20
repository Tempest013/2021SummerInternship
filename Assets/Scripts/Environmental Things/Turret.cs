using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    protected PlayerCharacter player;

    [SerializeField] private bool inRange;

    [SerializeField] private ParticleSystem flame;
    [SerializeField] private GameObject flameSystem;

    //Player Damage
    public ArmorUI pArmor;
    public PlayerHealth pHealth;

    private IEnumerator flameDamage;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerCharacter.instance;
        flame.Stop();
        flameSystem.SetActive(false);

        flameDamage = Burning(3);

    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            this.gameObject.transform.LookAt(player.transform);
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            flameSystem.SetActive(true);
            flame.Play();

           

            StartCoroutine(flameDamage);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            flame.Stop();
            //flameSystem.SetActive(false);

            StopCoroutine(flameDamage);
           
        }
    }

    IEnumerator Burning(float burnDuration)
    {
       while(true)
        {
             yield return new WaitForSeconds(burnDuration);
             player.TakeDamage(20);
        }
       


    }
}
