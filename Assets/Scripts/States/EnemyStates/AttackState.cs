using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    public AttackState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }

    MonoBehaviour mono;
    public override void Enter()
    {

        enemy.PlayAudio(enemy.AttackSFX, .75f);
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
