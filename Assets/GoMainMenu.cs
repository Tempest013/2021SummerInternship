using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMainMenu : MonoBehaviour
{
    PlayerCharacter player;
    GameManager gameManager;
    private void Start()
    {
        player = PlayerCharacter.instance;
        gameManager = GameManager.instance;
    }
    public void GoToMenu()
    {
        player.transform.parent = gameManager.transform;
        GameManager.instance.GameplayState.SwitchToMenuState();
        PlayerCharacter.instance.CurrState.SwitchToAirState();
        SceneManagement.instance.loadNextScene("MainMenu");
    }
}
