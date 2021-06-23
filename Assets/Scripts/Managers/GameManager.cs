using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    private PlayerCharacter player;

    //States
    private GameStates currState;
    private PauseState pauseState;
    private GameplayState gameplayState;
    private WeaponSwapState weaponSwapState;
    private TextBoxState textBoxState;
    private DeathState deathState;


    //UI EVENTS
    public UnityAction onTurnOnPauseUI;
    public UnityAction onTurnOffPauseUI;
    public UnityAction onTurnOnWeaponSwapUI;
    public UnityAction onTurnOffWeaponSwapUI;
    public UnityAction onTurnOnDeathUI;
    public UnityAction onTurnOffDeathUI;
    

    public UnityAction stopFiring;
    public UnityAction ResetCameraMovement;

    [SerializeField] private float weaponMenuSpeed = .1f;


    public PauseState PauseState { get => pauseState; }
    public GameplayState GameplayState { get => gameplayState; }
    public GameStates CurrState { get => currState;  }
    public float WeaponMenuSpeed { get => weaponMenuSpeed; }
    public WeaponSwapState WeaponSwapState { get => weaponSwapState;  }
    public PlayerCharacter Player { get => player;  }
    public TextBoxState TextBoxState { get => textBoxState;}
    public DeathState DeathState { get => deathState; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        //State Initialization 
        pauseState = new PauseState();
        gameplayState = new GameplayState();
        weaponSwapState = new WeaponSwapState();
        textBoxState = new TextBoxState();
        deathState = new DeathState();


        currState = GameplayState;

        player = PlayerCharacter.instance;

    }



    void Update()
    {
      
        currState = (GameStates)CurrState.Process();
    }
   
}
