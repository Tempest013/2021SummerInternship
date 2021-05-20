using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyBase
{
    [SerializeField] private GameObject spawner;
    private bool hasShot = false;
    // Start is called before the first frame update
    void Start()
    {

        AggresiveState = new AggresiveRangeState(this, anim);

        IdleState = new IdleState(this, anim);

        currState = IdleState;
    }

    // Update is called once per frame
    void Update()
    {
        currState = (EnemyState)currState.Process();
        if (currState == AggresiveState && !hasShot)
        {
            Vector3 lookAtPos = PlayerCharacter.instance.gameObject.transform.position;
            lookAtPos.y = 0;
            this.gameObject.transform.LookAt(lookAtPos);
            StartCoroutine(StartFiring());
            ObjectPooling.instance.SpawnFromPool("EnemyBullet", spawner.transform.position, Quaternion.identity);
        }
    }

    public IEnumerator StartFiring()
    {
        hasShot = true;
        yield return new WaitForSeconds(2f);
        hasShot = false;
    }

    
}
