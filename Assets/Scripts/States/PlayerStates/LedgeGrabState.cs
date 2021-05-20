using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to determine a ledge 
//check if a collision is happening in front of character
//Then do a raycast starting from above the player to see if he can ledge climb

public class LedgeGrabState : PlayerStates
{
    private Vector3 pointToClimbTo;
    private float climbTime;
    private List<Vector3> pointsBrokenUp = new List<Vector3>();
    private int currWaypoint;
    private float xToLerpTo;

    private bool currentlyFiring;
    public Vector3 PointToClimbTo { get => pointToClimbTo; set => pointToClimbTo = value; }
    public override void Enter()
    {

        currentlyFiring = SaveWasFiring(currentlyFiring);
        CreatePath();
        CameraFocus();
        base.Enter();
    }

    private void CreatePath()
    {
        pointsBrokenUp.Clear();
        currWaypoint = 0;
        pointsBrokenUp.Add(new Vector3(player.transform.position.x, PointToClimbTo.y + player.Collider.height / 2, player.transform.position.z));
        pointsBrokenUp.Add(new Vector3(pointToClimbTo.x, PointToClimbTo.y + player.Collider.height / 2, pointToClimbTo.z));
    }

    private void CameraFocus()
    {
        player.cam.transform.LookAt(pointsBrokenUp[currWaypoint]);
        xToLerpTo = player.cam.transform.rotation.x;
        player.cam.transform.localEulerAngles = new Vector3(player.RotationOnX, 0f, 0f);
    }

    public override void Update()
    {
        MoveLerp(pointsBrokenUp, ref currWaypoint, player.LedgeGrabSpeed, SwitchToGroundedState, player.LedgeGrabDelay);
        CameraControls();
    }


    public LedgeGrabState(PlayerCharacter player, Animator anim) : base(player, anim) { }
    public override void CameraControls()
    {
        player.RotationOnX = Mathf.Lerp(player.RotationOnX, xToLerpTo, player.LedgeGrabCameraSpeed);
        player.RotationOnX = Mathf.Clamp(player.RotationOnX, -80f, 80f);
        player.cam.transform.localEulerAngles = new Vector3(player.RotationOnX, 0f, 0f);
        player.Transform.Rotate(Vector3.up * player.MouseLook.x);
    }
    public override void Exit()
    {
        if (currentlyFiring)
            base.PrimaryFire();
        base.Exit();
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
    public override void AltFire() { }
    public override void StopAltFire() { base.StopAltFire(); }
    public override void Jump() { }
    public override void Melee() { }
    #endregion EmptyOverrides
}
