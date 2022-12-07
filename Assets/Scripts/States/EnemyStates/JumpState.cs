using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : EnemyState
{
    public JumpState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }

    public override void Enter()
    {
        enemy.anim.SetTrigger("Jump");
        base.Enter();
    }

    public override void Update()
    {
        if(!enemy.agent.isOnOffMeshLink)
        {
            SwitchToAggresiveState();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
