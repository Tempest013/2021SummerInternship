using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    public AttackState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }

    private float sTime = 0f;
    private float delayTime = 0.5f;
    MonoBehaviour mono;
    public override void Enter()
    {
        base.Enter();
        enemy.anim.SetTrigger("Attacking");
        
        
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        enemy.inRange = false;
        base.Exit();
    }
}
