using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    //States
    private GameStates currState;
    private PauseState pauseState;
    private GameplayState gameplayState;
    private WeaponSwapState weaponSwapState;


    //UI EVENTS
    public UnityAction onTurnOnPauseUI;
    public UnityAction onTurnOffPauseUI;
    public UnityAction onTurnOnWeaponSwapUI;
    public UnityAction onTurnOffWeaponSwapUI;



    public UnityAction stopFiring;
    public UnityAction ResetCameraMovement;

    [SerializeField] private float weaponMenuSpeed = .1f;


    public PauseState PauseState { get => pauseState; }
    public GameplayState GameplayState { get => gameplayState; }
    public GameStates CurrState { get => currState;  }
    public float WeaponMenuSpeed { get => weaponMenuSpeed; }
    public WeaponSwapState WeaponSwapState { get => weaponSwapState;  }

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

        currState = GameplayState;

    }


    // Update is called once per frame
    void Update()
    {
        currState = (GameStates)CurrState.Process();
    }

    //create an event that when called switches gamestate to weaponSwap State
    //Create an event that when called switches gamestate to Pause State



}
