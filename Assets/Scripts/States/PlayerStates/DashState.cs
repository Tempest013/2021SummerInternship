using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DashState : PlayerStates
{
    public DashState(PlayerCharacter player, Animator anim) : base(player, anim) { }
    private Vector3 direction;

    private IEnumerator stopDash;
    public override void Enter()
    {
        nextState = null;
        player.StartCoroutine(player.StartDash());
        stopDash = StopDash();
        player.StartCoroutine(stopDash);
        DetermineDirection();
        player.PlayAudioClip(player.DashAudioClip,1);
        base.Enter();
    }

    private void DetermineDirection()
    {
        if (player.XMovement == 0 && player.YMovement == 0)
            direction = player.transform.forward;
        else
            direction = player.transform.right * player.CurrXMovement + player.transform.forward * player.CurrYMovement;
        direction = direction.normalized;
    }


    public override void Update()
    {
        //TODO
        Move(player.DashSpeed, 0);
        RayCastStop();
        CameraControls();
    }
    public override void Exit()
    {
        player.StopCoroutine(stopDash);
        //TODO
        if (!(nextState is SwingingState))
        {
            if (player.Controller.isGrounded)
                SwitchToGroundedState();
            else
                SwitchToAirState();
            player.CurrZMovement = player.InitialFallSpeed;
        }
        base.Exit();
    }
    public IEnumerator StopDash()
    {

        yield return new WaitForSeconds(player.DashTime);
        if (phase != Phase.EXIT)
            phase = Phase.EXIT;
    }
    public override void Move(float acceleration, float forceOfGravity)
    {
        player.Controller.Move((direction * acceleration) * Time.deltaTime);
    }

    //May need to change this to account for height
    private void RayCastStop()
    {
        Vector3 bottomBody = new Vector3(player.transform.position.x, player.transform.position.y - ((player.Collider.height / 2)-player.Collider.radius),
            player.transform.position.z);
        Vector3 topBody = new Vector3(player.transform.position.x, player.transform.position.y + ((player.Collider.height / 2)-player.Collider.radius),
            player.transform.position.z);
        if (Physics.CapsuleCast(bottomBody,topBody,player.Collider.radius,direction,1,player.DashLayerMask))
        {
            if (phase != Phase.EXIT)
                phase = Phase.EXIT;
        }
    }
    public override void Dash() { }
}
