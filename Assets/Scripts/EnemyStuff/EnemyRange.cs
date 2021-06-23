using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    [SerializeField] private GameObject spawner;
    private bool hasShot = false;
    public GameObject me;

    public GameObject Spawner { get => spawner; set => spawner = value; }

    // Start is called before the first frame update
    void Start()
    {
        me = this.gameObject;
        AggresiveState = new AggresiveRangeState(this, anim);

        IdleState = new IdleState(this, anim);

        AttackingState = new AttackRangeState(this, anim);

        DeadedState = new DeadState(this, anim);

        currState = IdleState;
    }

    // Update is called once per frame
    void Update()
    {
        currState = (EnemyState)currState.Process();
        Debug.Log(currState);
    }

    public void startTheFiring()
    {
        StartCoroutine(StartFiring());
    }

    public IEnumerator StartFiring()
    {
        hasShot = true;
        yield return new WaitForSeconds(2f);
        hasShot = false;
    }

    
}
