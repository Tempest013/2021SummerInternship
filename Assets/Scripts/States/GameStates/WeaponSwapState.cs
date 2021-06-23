using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapState : InputStates
{
    //IN DOOM basic movement so jumping and walking are allowed but you cant dash or shoot 
    //A small radial menu appears and then based on your mouse position when you let go of the button 
    //it will select a weapon


    public override void OnWeaponSwap()
    {
        SwitchToGameplayState();
    }
    public override void Enter()
    {
        Time.timeScale = gamemanager.WeaponMenuSpeed;
        UnlockCursor();
        gamemanager.ResetCameraMovement?.Invoke();
        gamemanager.stopFiring?.Invoke();
        gamemanager.onTurnOnWeaponSwapUI?.Invoke();

        base.Enter();
    }



    public override void Exit()
    {
        Time.timeScale = 1f;
        gamemanager.onTurnOffWeaponSwapUI?.Invoke();
        base.Exit();
    }

    

}
