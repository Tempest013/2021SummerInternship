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


    //Cashed Variables
    public Animator anim;
    public Rigidbody body;
    public NavMeshAgent agent;
    public Health health;




    public IdleState IdleState { get => idleState; set => idleState = value; }
    public AggresiveState AggresiveState { get => aggresiveState; set => aggresiveState = value; }

    void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        health = this.GetComponent<Health>();
    }

    void Start()
    {
        
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

}
