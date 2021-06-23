using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyState
{
    public DeadState(EnemyBase enemy, Animator anim):base(enemy, anim) { }

    public override void Enter()
    {
        anim.SetBool("isDead", true);
        base.Enter();
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {


        base.Exit();
    }
}
