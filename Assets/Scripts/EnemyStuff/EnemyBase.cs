using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    //States
    public EnemyState currState;
    private IdleState idleState;
    private AggresiveState aggresiveState;
    private AttackState attackState;
    private DeadState deadState;

    //Cashed Variables
    public Animator anim;
    public Rigidbody body;
    public NavMeshAgent agent;
    public Health health;


    public bool inRange = false;

    public IdleState IdleState { get => idleState; set => idleState = value; }
    public AggresiveState AggresiveState { get => aggresiveState; set => aggresiveState = value; }
    public AttackState AttackingState { get => attackState; set => attackState = value; }
    public DeadState DeadedState { get => deadState; set => deadState = value; }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        health = this.GetComponent<Health>();
    }

    void Start()
    {
        
    }

    public void Die()
    {
        currState.SwitchToDeadState();
    }

}
