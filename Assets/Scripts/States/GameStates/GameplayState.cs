using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameStates
{
    public override void Enter()
    {
        Time.timeScale = 1f;
        LockCursor();
        base.Enter();
    }


}
