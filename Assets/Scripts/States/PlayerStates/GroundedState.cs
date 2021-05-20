using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GroundedState : PlayerStates
{
    public GroundedState(PlayerCharacter player, Animator anim) : base(player, anim) { }
    public override void Enter()
    {
        player.AirState.HasDoubleJumped = false;
        player.CurrZMovement =player.InitialFallSpeed;
        base.Enter();
    }
    public override void Update()
    {
        Move(player.GroundAcceleration,0);
        CameraControls();
        if (!player.Controller.isGrounded)
            SwitchToAirState(false);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
