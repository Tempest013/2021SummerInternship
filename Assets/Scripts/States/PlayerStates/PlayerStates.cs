using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 
/// FORSURE STATES
/// DashState
/// GroundedState
/// AirState
/// 
/// MAYBE STATES
/// SwingingState
/// WallClimbState
/// GrappleState
/// </summary>


public class PlayerStates :State
{
    //TODO MAKE FUNCTIONS THAT WILL BE UNIVERSAL TO THE STATES

    //Variables
    protected PlayerCharacter player;
    protected Animator anim;
    public delegate void SwitchDelegate(bool x);

    //Getters and Setters
    public PlayerCharacter Player { get => player; set => player = value; }
    public Animator Anim { get => anim; set => anim = value; }

    public PlayerStates(PlayerCharacter player,Animator anim)
    {
        this.Player = player;
        this.Anim = anim;
    }

    public override void Update()
    {
        CameraControls();
    }
    public void StopAllFire()
    {
        StopAltFire();
        StopPrimaryFire();
    }
    public virtual void CameraControls()
    {
       // Debug.Log("zach sucks");
        player.RotationOnX -= player.MouseLook.y;
        player.RotationOnX = Mathf.Clamp(player.RotationOnX, -80f, 80f);
        player.cam.transform.localEulerAngles = new Vector3(player.RotationOnX, 0f, 0f);
       // pRigidBody.cam.transform.localRotation = Quaternion.Euler(pRigidBody.rotationOnX, 0f, 0f);
        player.Transform.Rotate(Vector3.up * player.MouseLook.x);
    }
    public virtual void MoveLerp(List<Vector3> path,ref int currWaypoint, float speed,SwitchDelegate stateSwitch,float transitionDelay )
    {
        float posy = Mathf.Lerp(player.transform.position.y, path[currWaypoint].y, speed * Time.deltaTime);
        float posz = Mathf.Lerp(player.transform.position.z, path[currWaypoint].z, speed * Time.deltaTime);
        float posx = Mathf.Lerp(player.transform.position.x, path[currWaypoint].x, speed * Time.deltaTime);
        if (Vector3.Distance(player.transform.position, path[currWaypoint]) < transitionDelay)
        {
            //Might need to change 
            if (currWaypoint + 1 == path.Count)
                stateSwitch(false);
            else
                currWaypoint += 1;

        }
        player.transform.position = new Vector3(posx, posy, posz);
    }
    public virtual void Move() { }
    public virtual void Move(float acceleration,float gravity)
    {
        player.CurrXMovement = Mathf.Lerp(player.CurrXMovement, player.XMovement, acceleration * Time.deltaTime);
        player.CurrYMovement = Mathf.Lerp(player.CurrYMovement, player.YMovement, acceleration * Time.deltaTime);
        player.CurrZMovement -= -gravity * Time.deltaTime;
        if ((player.CurrYMovement < .01 && player.CurrYMovement > 0) || (player.CurrYMovement > -.01 && player.CurrYMovement < 0))
            player.CurrYMovement = 0;
        if ((player.CurrXMovement < .01 && player.CurrXMovement > 0) || (player.CurrXMovement > -.01 && player.CurrXMovement < 0))
            player.CurrXMovement = 0;
        Vector3 movement = player.transform.right * player.CurrXMovement 
            + player.transform.forward * player.CurrYMovement +player.transform.up*player.CurrZMovement;    
        player.Controller.Move(movement * player.GroundMoveSpeed * Time.deltaTime);
    }
    public virtual void PrimaryFire()
    {
        player.equipedWeapon.FirePrimary();
    }
    public virtual void StopPrimaryFire()
    {
        player.equipedWeapon.StopPrimary();
    }
     public bool SaveWasFiring(bool currentlyFiring)
    {
        bool wasFiring=false;
        if (player.equipedWeapon != null)
           wasFiring = player.equipedWeapon.IsShooting;
        StopAllFire();
        currentlyFiring = wasFiring;
        return currentlyFiring;
    }

    public virtual void AltFire()
    {
        //Functionality

    }
    public virtual void StopAltFire()
    {
        //TODO
    }
    public virtual void Dash()
    {
        if (!player.IsDashonCooldown)
            SwitchToDashState();
        
    }
    public virtual void Jump()
    {
        player.CurrZMovement =player.JumpForce;

    }
    public virtual void Melee()
    {
        //TODO

    }
    public virtual void Grenade()
    {
        player.Grenade.ThrowGrenade();
    }

    #region StateSwitches

    
    public void SwitchToDashState()
    {
        SwitchToShell(player.DashState);
    }
    public void SwitchToGroundedState()
    {
        SwitchToShell(player.GroundedState);
    }
    public void SwitchToGroundedState(bool filler)
    {
        SwitchToShell(player.GroundedState);
    }
    public void SwitchToAirState()
    {
        SwitchToShell(player.AirState);
    }
    public void SwitchToAirState(bool hasDoubleJumped)
    {
        SwitchToShell(player.AirState);
        player.AirState.HasDoubleJumped=hasDoubleJumped;
    }
    public void SwitchToSwingState()
    {
        SwitchToShell(player.SwingState);
    }
    public void SwitchToLedgeGrabState(Vector3 pointToClimbTo)
    {
        SwitchToShell(player.LedgeGrabState);
        player.LedgeGrabState.PointToClimbTo = pointToClimbTo;
    }

    public void SwitchToClimbingState()
    {
        SwitchToShell(player.ClimbingState);
    }

    #endregion StateSwitches

}
