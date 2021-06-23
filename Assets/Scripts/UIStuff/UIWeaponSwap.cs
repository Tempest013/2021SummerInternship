using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWeaponSwap : MonoBehaviour
{
    [SerializeField] private GameObject combatUI;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            gameManager = GameManager.instance;
            gameManager.onTurnOnWeaponSwapUI += TurnOnCombatUI;
            gameManager.onTurnOffWeaponSwapUI += TurnOffCombatUI;
        }
    }

    public void SwapToAR()
    {
        PlayerCharacter.instance.SwapWeapon(1);
        gameManager.CurrState.SwitchToGameplayState();
    }
    public void SwapToShotgun()
    {
        gameManager.CurrState.SwitchToGameplayState();
        PlayerCharacter.instance.SwapWeapon(2);
    }
    public void SwapToRocket()
    {
        PlayerCharacter.instance.SwapWeapon(3);
        gameManager.CurrState.SwitchToGameplayState();
    }
    public void SwapToBigBoomer()
    {
        PlayerCharacter.instance.SwapWeapon(4);
        gameManager.CurrState.SwitchToGameplayState();
    }
    private void TurnOffCombatUI()
    {
        combatUI.SetActive(false);
    }
    private void TurnOnCombatUI()
    {
        combatUI.SetActive(true);
    }
}
