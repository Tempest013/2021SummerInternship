using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameStates
{
    public override void Enter()
    {
        Time.timeScale = 0;
        UnlockCursor();
        gamemanager.stopFiring?.Invoke();
        base.Enter();
    }
    public override void Update()
    {

    }

    public override void Exit()
    {
    
        base.Exit();
    }



}
