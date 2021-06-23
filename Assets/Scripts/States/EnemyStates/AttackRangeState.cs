using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeState : AttackState
{
    public AttackRangeState(EnemyBase enemy, Animator anim) : base(enemy, anim) { }
    public override void Enter()
    {
        Vector3 lookAtPos = PlayerCharacter.instance.gameObject.transform.position;
        lookAtPos.y = 0;
        enemy.gameObject.transform.LookAt(lookAtPos);
        enemy.GetComponent<EnemyRange>().startTheFiring();
        ObjectPooling.instance.SpawnFromPool("EnemyBullet", enemy.GetComponent<EnemyRange>().Spawner.transform.position, Quaternion.identity);
        base.Enter();
    }

    public override void Update()
    {
        if (10f > Vector3.Distance(PlayerCharacter.instance.transform.position, enemy.transform.position))
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
