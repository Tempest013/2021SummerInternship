using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }


    public override void Enter()
    {
        //things to do


        base.Enter();
    }


    public override void Update()
    {
        if(25f > Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position))
        {
            SwitchToAggresiveState();
            
        }

    }


    public override void Exit()
    {
        //things to do


        base.Exit();
    }
}
