using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : GameStates
{
    public override void Enter()
    {
        gamemanager.Player.StopCameraMovement();
        Time.timeScale = 0;
        UnlockCursor();
        gamemanager.onTurnOnDeathUI?.Invoke();
        base.Enter();
    }

    public override void Exit()
    {
        gamemanager.onTurnOffDeathUI?.Invoke();
        base.Exit();
    }


}
