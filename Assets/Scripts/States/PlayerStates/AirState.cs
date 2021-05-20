using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//TODO WALLCLIMB CHECK

public class AirState : PlayerStates
{
    public AirState(PlayerCharacter player, Animator anim) : base(player, anim) { }

   private bool hasDoubleJumped = false;

    
    public bool HasDoubleJumped {  set => hasDoubleJumped = value; }

    public override void Enter()
    {

       
        base.Enter();
    }

    public override void Update()
    {
        
        CameraControls();
        Move(player.AirAcceleration, player.ForceOfGravity);
        if (player.Controller.isGrounded)
            SwitchToGroundedState();
        if(!CeilingCheck())
        WallClimbCheck();
    }
    public override void Jump()
    {
        if (hasDoubleJumped == false)
        {
            base.Jump();
            HasDoubleJumped = true;
        }
    }
    public void WallClimbCheck()
    {
        Transform playerPos = player.transform;
        //Debug.DrawRay(player.transform.position, player.transform.forward);
        //Debug.DrawRay(new Vector3(playerPos.position.x + playerPos.forward.x, 
        //              playerPos.position.y + player.Collider.height / 2, playerPos.position.z + playerPos.forward.z), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(playerPos.position.x + playerPos.forward.x,
            playerPos.position.y + player.Collider.height / 2, playerPos.position.z + playerPos.forward.z),
            Vector3.down, out hit, player.Collider.height-player.Collider.radius-player.LedgeGrabLowerSize,
            player.PlatformLayerMask )&&player.CurrYMovement>0.2)
        {
            RaycastHit hit2;
            if (!Physics.SphereCast(new Vector3(hit.point.x, hit.point.y + player.Collider.radius, hit.point.z)
                ,player.Collider.radius, Vector3.up, out hit2, player.Collider.height - player.Collider.radius,player.PlatformLayerMask))
            {
                SwitchToLedgeGrabState(hit.point);
            }
        }  
    }
    private bool CeilingCheck()
    {
        Debug.DrawRay(new Vector3(player.transform.position.x, player.transform.position.y + player.Collider.height/2, player.transform.position.z),
            Vector3.up,Color.red); 
        if (Physics.Raycast(new Vector3(player.transform.position.x, player.transform.position.y + player.Collider.height / 2, player.transform.position.z),
            Vector3.up, .2f))
        {
            player.CurrZMovement = player.InitialFallSpeed;
            return true;
        }
        return false;
    }
    public override void Exit()
    {
        base.Exit();
    }

   
}

