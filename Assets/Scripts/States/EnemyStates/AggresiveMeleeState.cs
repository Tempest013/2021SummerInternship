using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggresiveMeleeState : AggresiveState
{
    BoxCollider boxer;
    public AggresiveMeleeState(EnemyBase enemy, Animator anim):base(enemy, anim) { }

    public override void Enter()
    {
        base.Enter();
        boxer = enemy.GetComponent<EnemyMelee>().meleeHitRange;
        enemy.anim.SetBool("isMoving", true);
    }

    public override void Update()
    {
        enemy.agent.SetDestination(PlayerCharacter.instance.transform.position);
        if(enemy.agent.isOnOffMeshLink)
        {
            SwitchToJumpState();
        }
        if (enemy.inRange == true)
        {
            enemy.agent.SetDestination(enemy.gameObject.transform.position);
            SwitchToAttackState();
        }
        
    }
    
    

    

    public override void Exit()
    {
        enemy.agent.SetDestination(enemy.transform.position);
        enemy.anim.SetBool("isMoving", false);
        base.Exit();
    }
}
