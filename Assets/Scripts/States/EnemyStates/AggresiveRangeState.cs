using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveRangeState : AggresiveState
{
    public AggresiveRangeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //Debug.Log(Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position));
        if (10f < Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position))
        {
            enemy.agent.SetDestination(PlayerCharacter.instance.transform.position);
            
        }
        else if (10f > Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position))
        {
            enemy.agent.SetDestination(enemy.transform.position);

            //Debug.Log("Shoot");
        }
    }

    public override void Exit()
    {


        base.Exit();
    }

}
