using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveRangeState : AggresiveState
{
    public AggresiveRangeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }
    private float sTime = 0f;
    private float delayTime = 3f;

    public override void Enter()
    {
        enemy.anim.SetBool("isMoving", true);
        enemy.agent.SetDestination(PlayerCharacter.instance.transform.position);

        base.Enter();
    }

    public override void Update()
    {
        enemy.agent.SetDestination(PlayerCharacter.instance.transform.position);
        if (10f < Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position))
        {
             if((Time.time - sTime) > delayTime)
             {
                sTime = Time.time;
                enemy.agent.SetDestination(enemy.gameObject.transform.position);
                SwitchToAttackState();
             }

        }
    }

    public override void Exit()
    {


        base.Exit();
    }

}
