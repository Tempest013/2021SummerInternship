using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeState : AttackState
{
    private float sTime = 0f;
    private float delayTime = 3f;
    private bool onlyonce = false;
    public AttackRangeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }
    public override void Enter()
    {
        Vector3 lookAtPos = PlayerCharacter.instance.gameObject.transform.position;
        lookAtPos.y = 0;
        enemy.gameObject.transform.LookAt(lookAtPos);
        enemy.GetComponent<EnemyRange>().startTheFiring();
        if (!onlyonce)
        {
            onlyonce = true;
            ObjectPooling.instance.SpawnFromPool("EnemyBullet", enemy.GetComponent<EnemyRange>().Spawner.transform.position, Quaternion.identity);
        }
        RangedAttacked = true;
        enemy.anim.SetBool("isMoving", false);
        enemy.anim.SetTrigger("Attacking");

        StaticCoroutine.StartCoroutine(AttackDelay());

        base.Enter();
    }

    public IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1f);
        SwitchToAggresiveState();
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        onlyonce = false;
        enemy.anim.SetBool("isMoving", true);
        base.Exit();
    }

}
