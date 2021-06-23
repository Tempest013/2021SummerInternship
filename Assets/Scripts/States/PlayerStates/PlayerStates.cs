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


public class PlayerStates : State
{
    //TODO MAKE FUNCTIONS THAT WILL BE UNIVERSAL TO THE STATES

    //Variables
    protected PlayerCharacter player;
    protected Animator anim;
    public delegate void SwitchDelegate(bool x);

    //Getters and Setters
    public PlayerCharacter Player { get => player; set => player = value; }
    public Animator Anim { get => anim; set => anim = value; }

    public PlayerStates(PlayerCharacter player, Animator anim)
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

    protected Vector3 SetHandPosLedgeGrab(float positionY)
    {
        Vector3 pos = player.Arms.transform.localPosition;
        player.Arms.transform.position += (player.transform.forward.normalized / 2.25f);
        return pos;
    }
    protected Vector3 SetHandPosSwing(Vector3 newPos)
    {
        Vector3 pos = player.Arms.transform.localPosition;
        player.Arms.transform.position -= (player.transform.right / 2);
      
        return pos;
    }
    protected Vector3 SetHandPosDeath()
    {
        Vector3 pos = player.Arms.transform.localPosition;
        player.Arms.transform.position =  player.transform.forward / 2 ;
        return pos;
    }
    protected void SetArmsPosSwing(Vector3 position, Transform armsParent, Quaternion armsRotation)
    {
       // player.Arms.transform.parent = armsParent;
        player.Arms.transform.localRotation = armsRotation;
        player.Arms.transform.localPosition = position;
    }
    protected void SetArmsPos(Vector3 position)
    {
        player.Arms.transform.localPosition = position;
    }
    //FUCKING FAILURE
    //protected void SetIKValuesForHands(Vector3 positition)
    //{
    //    player.Anim.SetLookAtWeight(1);
    //    player.Anim.SetLookAtPosition(positition);



    //    player.Anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
    //    player.Anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
    //    player.Anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
    //    player.Anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);

    //    player.Anim.SetIKPosition(AvatarIKGoal.RightHand, positition + player.transform.right.normalized + (player.transform.forward.normalized * 2));
    //    player.Anim.SetIKPosition(AvatarIKGoal.LeftHand, positition - player.transform.right.normalized + (player.transform.forward.normalized * 2));

    //}

    //protected void RemoveIKValues()
    //{
    //    player.Anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
    //    player.Anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
    //    player.Anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
    //    player.Anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
    //    player.Anim.SetLookAtWeight(0);
    //}
    public virtual void CameraControls()
    {
        player.RotationOnX -= player.MouseLook.y;
        player.RotationOnX = Mathf.Clamp(player.RotationOnX, -80f, 80f);
        player.cam.transform.localEulerAngles = new Vector3(player.RotationOnX, 0f, 0f);
        // pRigidBody.cam.transform.localRotation = Quaternion.Euler(pRigidBody.rotationOnX, 0f, 0f);
        player.Transform.Rotate(Vector3.up * player.MouseLook.x);
    }
    public virtual void MoveLerp(List<Vector3> path, ref int currWaypoint, float speed, SwitchDelegate stateSwitch, float transitionDelay)
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
    public virtual void Move(float acceleration, float gravity)
    {
        if (player.IsInputState())
        {
            player.CurrXMovement = Mathf.Lerp(player.CurrXMovement, player.XMovement, acceleration * Time.deltaTime);
            player.CurrYMovement = Mathf.Lerp(player.CurrYMovement, player.YMovement, acceleration * Time.deltaTime);
            player.CurrZMovement -= -gravity * Time.deltaTime;
            if ((player.CurrYMovement < .01 && player.CurrYMovement > 0) || (player.CurrYMovement > -.01 && player.CurrYMovement < 0))
                player.CurrYMovement = 0;
            if ((player.CurrXMovement < .01 && player.CurrXMovement > 0) || (player.CurrXMovement > -.01 && player.CurrXMovement < 0))
                player.CurrXMovement = 0;
            Vector3 movement = player.transform.right * player.CurrXMovement
                + player.transform.forward * player.CurrYMovement + player.transform.up * player.CurrZMovement;
            player.Controller.Move(movement * player.GroundMoveSpeed * Time.deltaTime);
        }
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
        bool wasFiring = false;
        if (player.equipedWeapon != null)
            wasFiring = player.equipedWeapon.IsShooting;
        StopAllFire();
        currentlyFiring = wasFiring;
        return currentlyFiring;
    }
    protected void EnterAnimStateDisableGunBool(string animState)
    {
        player.equipedWeapon.gameObject.SetActive(false);
        player.ArmsAnim.SetBool(animState, true);
    }
    protected void ExitAnimStateEnableGunBool(string animState)
    {
        player.equipedWeapon.gameObject.SetActive(true);
        player.ArmsAnim.SetBool(animState, false);
    }
    protected void EnterAnimStateDisableGunTrigger(string animState)
    {
        player.equipedWeapon.gameObject.SetActive(false);
        player.ArmsAnim.SetTrigger(animState);
    }
    protected void EnableGun()
    {
        player.equipedWeapon.gameObject.SetActive(true);
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
        player.CurrZMovement = player.JumpForce;

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

    public void SwitchToPlayerDeathState()
    {
        SwitchToShell(player.DeathState);
    }

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
        player.AirState.HasDoubleJumped = hasDoubleJumped;
    }
    public void SwitchToSwingState(Vector3 polePosition)
    {
        SwitchToShell(player.SwingState);
        player.SwingState.polePosition = polePosition;
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
