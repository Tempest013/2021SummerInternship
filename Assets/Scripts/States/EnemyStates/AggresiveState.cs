using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggresiveState : EnemyState
{
    public AggresiveState(EnemyBase enemy, Animator anim): base(enemy, anim) { }


    public override void Enter()
    {
        //things to do


        base.Enter();
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        //things to do

        base.Exit();
    }
}
