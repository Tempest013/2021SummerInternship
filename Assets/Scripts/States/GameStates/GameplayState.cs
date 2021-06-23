using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : InputStates
{
    public override void Enter()
    {
        
        Time.timeScale = 1f;
        LockCursor();
        base.Enter();
    }


}
