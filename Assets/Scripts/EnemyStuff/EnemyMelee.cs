using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    [SerializeField] private float sTime = 0f;
    [SerializeField] private float delayTime = 2f;
    public delegate void HitAction();
    public static event HitAction OnHitMelee;

    public BoxCollider meleeHitRange;

    // Start is called before the first frame update
    void Start()
    {

        AggresiveState = new AggresiveMeleeState(this,anim);

        IdleState = new IdleState(this, anim);

        meleeHitRange = this.GetComponentInChildren<BoxCollider>();

        currState = IdleState;
    }

    // Update is called once per frame
    void Update()
    {
        currState = (EnemyState)currState.Process();
        //Debug.Log(currState);
    }






    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && currState == AggresiveState)
        {
            if((Time.time - sTime) > delayTime)
            {
                sTime = Time.time;
                Debug.Log("hurt");
                PlayerCharacter.instance.TakeDamage(25);
                
            }
        }
    }

    
}
