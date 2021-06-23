using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : State
{
    protected GameManager gamemanager;
   public GameStates()
    {
        gamemanager = GameManager.instance;
    }

    public virtual void OnPause()
    {
        if(gamemanager.Player.CurrState!=gamemanager.Player.DeathState)
        SwitchToPauseState();
    }

    public virtual void OnWeaponSwap()
    {
        SwitchToWeaponSwapState();
    }
    
    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    #region SwitchStates

    public void SwitchToGameplayState()
    {
        SwitchToShell(gamemanager.GameplayState);
    }

    public void SwitchToDeathState()
    {
        SwitchToShell(gamemanager.DeathState);
    }
    public void SwitchToTextBoxState()
    {
        SwitchToShell(gamemanager.TextBoxState);
    }
    public void SwitchToPauseState()
    {
        //may have a bug here
        gamemanager.PauseState.LastState = this;
        if (gamemanager.PauseState.LastState == gamemanager.WeaponSwapState)
            gamemanager.PauseState.LastState = gamemanager.GameplayState;
        SwitchToShell(gamemanager.PauseState);
    }
    public void SwitchToWeaponSwapState()
    {
        SwitchToShell(gamemanager.WeaponSwapState);
    }
    #endregion SwitchStates
}
