using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState :GameStates
{
    private GameStates lastState;

    public GameStates LastState { get=>lastState; set => lastState = value; }

    public override void Enter()
    {

        gamemanager.Player.StopCameraMovement();
        gamemanager.ChangeMusicVolume(.5f);
        Time.timeScale = 0;
        UnlockCursor();
        gamemanager.stopFiring?.Invoke();
        gamemanager.onTurnOnPauseUI?.Invoke();
        base.Enter();
    }

    public override void OnPause()
    {
        SwitchToShell(lastState);
    }
    public override void Exit()
    {
        gamemanager.ChangeMusicVolume(1);
        Time.timeScale = 1;
        gamemanager.onTurnOffPauseUI?.Invoke();
        base.Exit();
    }


}
