using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyState
{
    public DeadState(EnemyBase enemy, Animator anim):base(enemy, anim) { }

    public override void Enter()
    {
        enemy.PlayAudio(enemy.DeathSFX, .75f);
        enemy.IsDead = true;
        anim.SetBool("IsDead", true);
        WaveManager.onEnemyDeath?.Invoke();
        enemy.TurnOffParticleEffects();
        enemy.collider.enabled = false;
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
