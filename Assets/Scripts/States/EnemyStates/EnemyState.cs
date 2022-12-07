using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyState : State
{
    protected bool RangedAttacked = false;

    protected EnemyBase enemy;
    protected Animator anim;

    public EnemyBase Enemy { get => enemy; set => enemy = value; }
    public Animator Anim { get => anim; set => anim = value; }

    public EnemyState(EnemyBase enemy, Animator anim)
    {
        this.Enemy = enemy;
        this.Anim = anim;
    }

    public void SwitchToIdleState()
    {
        SwitchToShell(enemy.IdleState);
    }

    public void SwitchToAggresiveState()
    {
        SwitchToShell(enemy.AggresiveState);
    }

    public void SwitchToAttackState()
    {
        SwitchToShell(enemy.AttackingState);
    }

    public void SwitchToDeadState()
    {
        SwitchToShell(enemy.DeadedState);
    }

    public void SwitchToJumpState()
    {
        SwitchToShell(enemy.JumpState);
    }

    public void SwitchToBurnState()
    {
        SwitchToShell(enemy.BurnState);
    }

    public void SwitchToFrozenState()
    {
        SwitchToShell(enemy.FrozenState);
    }

    public void SwitchToPoisonState()
    {
        SwitchToShell(enemy.PoisonState);
    }

}
