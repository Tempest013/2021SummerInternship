using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxState : GameStates
{

    public override void Enter()
    {
        Time.timeScale = 0;
        gamemanager.Player.StopCameraMovement();
        gamemanager.Player.StopMovement();
        base.Enter();

    }
    public override void Update()
    {
    
    }
    public override void Exit()
    {
        Time.timeScale = 1;
        
        base.Exit();
    }
}
