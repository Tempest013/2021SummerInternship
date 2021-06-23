using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeState : AttackState
{
    public AttackMeleeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }
    float seconds = 1f;
    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Update()
    {
        seconds -= Time.deltaTime;
        if(seconds <= 0f)
        {
            SwitchToAggresiveState();
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
