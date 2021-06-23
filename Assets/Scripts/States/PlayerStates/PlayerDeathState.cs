using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState :PlayerStates
{

   
    private float timeToMenu = 2f;
    public PlayerDeathState(PlayerCharacter player, Animator anim) : base(player, anim) { }

    private Vector3 originalHandPos;

    #region EmptyOverrides
    public override void Move() { }
    public override void PrimaryFire() { }

    public override void Grenade() { }
    public override void Dash() { }

    public override void Jump() { }
    public override void CameraControls() { }
    public override void AltFire() { }
    public override void StopAltFire() { }
    public override void Melee() { }
 
    #endregion EmptyOverrides

    public IEnumerator startDeathMenu()
    {
        yield return new WaitForSeconds(timeToMenu);
        GameManager.instance.CurrState.SwitchToDeathState();
    }
    public override void Enter()
    {
        //EnterAnimStateDisableGunTrigger("isDead");
        originalHandPos = SetHandPosDeath();
        anim.SetTrigger("isDead");
        player.StartCoroutine(startDeathMenu());
        base.Enter();
    }

    public override void Exit()
    {
        player.Arms.transform.localPosition = originalHandPos;
        base.Exit();
    }

  

    public override void Update()
    {
       
       
    }

   
}
