using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// states for now
/// aggresive state
/// idle state
/// </summary>


public class EnemyState : State
{

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

}
