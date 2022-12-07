using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
    private MenuState menustate;

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
    [SerializeField] private AudioSource music;

    public PauseState PauseState { get => pauseState; }
    public GameplayState GameplayState { get => gameplayState; }
    public GameStates CurrState { get => currState; }
    public float WeaponMenuSpeed { get => weaponMenuSpeed; }
    public WeaponSwapState WeaponSwapState { get => weaponSwapState;  }
    public PlayerCharacter Player { get => player;  }
    public TextBoxState TextBoxState { get => textBoxState;}
    public DeathState DeathState { get => deathState; }
    public AudioSource Music { get => music; set => music = value; }
    public MenuState Menustate { get => menustate; set => menustate = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        pauseState = new PauseState();
        gameplayState = new GameplayState();
        weaponSwapState = new WeaponSwapState();
        textBoxState = new TextBoxState();
        deathState = new DeathState();
        menustate = new MenuState();
      
    }

    private void Start()
    {
        if (SceneManagement.instance != null)
        {
             currState = Menustate;
        }
        else
            currState = gameplayState;
        menustate.phase = State.Phase.ENTER;
        player = PlayerCharacter.instance;
    }

    public void PauseMusic()
    {
        if (music != null)
            music.Pause();
    }
    public void ResumeMusic()
    {
        if (music != null)
            music.Play();
    }
    public void ChangeMusicVolume(float volume)
    {
        if (music != null)
            music.volume = volume;
    }
    void Update()
    {
    
        currState = (GameStates)CurrState.Process();
    }
   
}
