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
        if (enemy.inRange == true)
        {
            SwitchToAttackState();
        }
        
    }
    
    

    

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool("isMoving", false);
    }
}
