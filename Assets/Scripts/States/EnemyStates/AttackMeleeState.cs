using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeState : AttackState
{
    public AttackMeleeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }
    float seconds = 1f;
    public override void Enter()
    {
        enemy.anim.SetTrigger("Attacking");
        base.Enter();
        
    }

    public override void Update()
    {
        if(!enemy.inRange)
        {
            SwitchToAggresiveState();
        }

    }

    public override void Exit()
    {
        enemy.inRange = false;
        base.Exit();
    }

}
