using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Things to account for/I need 
//Side of entry 
//object 

//THINGS TO DO CAMERA MOVEMENT IN SWING

public class SwingingState : PlayerStates
{
    public List<Vector3> path;
    private int currWaypoint;
    private bool currentlyFiring;
    public SwingingState(PlayerCharacter player, Animator anim) : base(player, anim) { }
    private Vector3 originalArmsPos;
    public Vector3 polePosition;
    private Transform armsParent;
    private Quaternion armsRotation;

    public override void Enter()
    {
        currentlyFiring = SaveWasFiring(currentlyFiring);
        float shortestdistance = 1000;
        for (int i = 0; i < path.Count; i++)
        {
            float currdistance = Vector3.Distance(player.transform.position, path[i]);
            if (currdistance < shortestdistance)
            {
                shortestdistance = currdistance;
                currWaypoint = i;
            }
        }
        armsRotation = player.Arms.transform.localRotation;
        originalArmsPos = SetHandPosSwing(polePosition);
        EnterAnimStateDisableGunTrigger("isSwinging");
        base.Enter();
    }

    public override void Update()
    {
        MoveLerp(path, ref currWaypoint, Player.SwingSpeed, SwitchToAirState, player.SwingGrabDelay);
        CameraControls();
    }

    public override void Exit()
    {
        EnableGun();
        if (currentlyFiring)
            base.PrimaryFire();
        Jump();
        SetArmsPosSwing(originalArmsPos,armsParent,armsRotation);
        
        base.Exit();
    }
    public override void CameraControls()
    {
        player.RotationOnX = Mathf.Lerp(player.RotationOnX, 0, player.SwingCameraSpeed);
        player.RotationOnX = Mathf.Clamp(player.RotationOnX, -80f, 80f);
        player.cam.transform.localEulerAngles = new Vector3(player.RotationOnX, 0f, 0f);
        player.GetComponent<Transform>().Rotate(Vector3.up * player.MouseLook.x);
    }
    #region EmptyOverrides
    public override void Dash() { }
    public override void PrimaryFire()
    {
        currentlyFiring = true;
    }
    public override void StopPrimaryFire()
    {
        base.StopPrimaryFire();
        currentlyFiring = false;

    }
    public override void AltFire()
    {

    }
    public override void StopAltFire()
    {

    }
    public override void Jump()
    {
        base.Jump();
    }
    public override void Melee()
    {

    }
    #endregion EmptyOverrides
}
