using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
public class PlayerCharacter : LivingEntities
{
    #region singleton
    public static PlayerCharacter instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton

    //Event Shit
    public delegate void DashAction();
    public static event DashAction OnDasher;
    public delegate void AmmoStuff();
    public static event AmmoStuff OnAmmoLoss;

    //input controls
    private Vector3 moveDirection;

    //look controls
    private Vector2 mouseLook;

    [SerializeField] private float mouseSensitivity = 20f;
    private float rotationOnX;
    public Camera cam;


    //Movement Control
    [Header("Movement Variables")]
    [SerializeField] private float groundMoveSpeed;
    [SerializeField] private float airAcceleration;
    [SerializeField] private float groundAcceleration;
    [SerializeField] private float forceOfGravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float initialFallSpeed = -1f;
    private float xMovement;
    private float yMovement;
    private float currXMovement = 0;
    private float currYMovement = 0;
    private float currZMovement = 0;
    [SerializeField] private LayerMask platformLayerMask;

    [Header("Ledge Grab Variables")]
    [SerializeField] private float ledgeGrabSpeed;
    [SerializeField] private float ledgeGrabDelay;
    [SerializeField] private float ledgeGrabCameraSpeed = .25f;
    [SerializeField] private float ledgeGrabLowerSize = .5f;

    [Header("Swinging Variables")]
    [SerializeField] private float swingSpeed = .5f;
    [SerializeField] private float swingGrabDelay;
    [SerializeField] private float swingCameraSpeed = .5f;

    [Header("Dash Variables")]
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private float dashSpeed = 10f;
    private bool isDashonCooldown;
    [SerializeField] private float dashTime = .5f;
    private DashBar dashbar;


    //Weapons
    [Header("Gun Variables")]
    [SerializeField] private GameObject bulletSpawner;
    [SerializeField] private Dictionary<int, Weapon> weaponDictonary = new Dictionary<int, Weapon>();
    [SerializeField] public Weapon equipedWeapon;

    //States
    private PlayerStates currState;
    private AirState airState;
    private GroundedState groundedState;
    private DashState dashState;
    private SwingingState swingState;
    private LedgeGrabState ledgeGrabState;
    private ClimbingState climbingState;

    //Cached Variables
    [Header("Cached Variables")]
    private Animator anim;
    private CharacterController controller;
    private Rigidbody body;
    private CapsuleCollider collider;
    private Transform transform;
    private GrenadeSpawner grenade;
    private GameManager gameManager;

    [Header("Player Stats")]
    public PlayerHealth health;
    public ArmorUI armor;
    [SerializeField] private bool isInvincible = false;
    public float IFrameDuration = 1f;

    #region Properties
    public AirState AirState { get => airState; }
    public GroundedState GroundedState { get => groundedState; }
    public DashState DashState { get => dashState; }
    public float GroundMoveSpeed { get => groundMoveSpeed; }
    public float XMovement { get => xMovement; }
    public float YMovement { get => yMovement; }
    public float AirAcceleration { get => airAcceleration; }
    public float GroundAcceleration { get => groundAcceleration; }
    public float CurrXMovement { get => currXMovement; set => currXMovement = value; }
    public float CurrYMovement { get => currYMovement; set => currYMovement = value; }
    public Vector2 MouseLook { get => mouseLook; set => mouseLook = value; }
    public float RotationOnX { get => rotationOnX; set => rotationOnX = value; }
    public float ForceOfGravity { get => forceOfGravity; }
    public float CurrZMovement { get => currZMovement; set => currZMovement = value; }
    public float JumpForce { get => jumpForce; }
    public float InitialFallSpeed { get => initialFallSpeed; }
    public float DashCooldown { get => dashCooldown; set => dashCooldown = value; }
    public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
    public bool IsDashonCooldown { get => isDashonCooldown; set => isDashonCooldown = value; }
    public float DashTime { get => dashTime; set => dashTime = value; }
    public GameObject BulletSpawner { get => bulletSpawner; set => bulletSpawner = value; }
    public DashBar Dashbar { get => dashbar; set => dashbar = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }
    public float MouseSensitivity { get => mouseSensitivity; set => mouseSensitivity = value; }
    public PlayerStates CurrState { get => currState; set => currState = value; }
    public Animator Anim { get => anim; set => anim = value; }
    public CharacterController Controller { get => controller; set => controller = value; }
    public Rigidbody Body { get => body; set => body = value; }
    public SwingingState SwingState { get => swingState; }
    public LedgeGrabState LedgeGrabState { get => ledgeGrabState; }
    public CapsuleCollider Collider { get => collider; set => collider = value; }
    public LayerMask PlatformLayerMask { get => platformLayerMask; }
    public ClimbingState ClimbingState { get => climbingState; set => climbingState = value; }
    public float LedgeGrabSpeed { get => ledgeGrabSpeed; }
    public float SwingGrabDelay { get => swingGrabDelay; }
    public float LedgeGrabDelay { get => ledgeGrabDelay; }
    public float SwingSpeed { get => swingSpeed; }
    public Transform Transform { get => transform; }
    public float SwingCameraSpeed { get => swingCameraSpeed; }
    public float LedgeGrabCameraSpeed { get => ledgeGrabCameraSpeed; }
    public float LedgeGrabLowerSize { get => ledgeGrabLowerSize; }
    public GrenadeSpawner Grenade { get => grenade; }
    public Dictionary<int, Weapon> WeaponDictonary { get => weaponDictonary; set => weaponDictonary = value; }


    #endregion Properties
    void Start()
    {

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //Cache Variables
        Anim = GetComponent<Animator>();
        cam = Camera.main;
        Controller = GetComponent<CharacterController>();
        Body = GetComponent<Rigidbody>();
        Collider = GetComponent<CapsuleCollider>();
        transform = GetComponent<Transform>();
        grenade = GetComponent<GrenadeSpawner>();
        gameManager = GameManager.instance;

        //States Initialization
        airState = new AirState(this, Anim);
        groundedState = new GroundedState(this, Anim);
        dashState = new DashState(this, Anim);
        ledgeGrabState = new LedgeGrabState(this, Anim);
        swingState = new SwingingState(this, Anim);
        climbingState = new ClimbingState(this, Anim);
        CurrState = groundedState;

        //Weapon Initialization
        WeaponDictonary = GetComponentsInChildren<Weapon>().OrderBy(x => x.id).ToDictionary(x => x.id);
        equipedWeapon = WeaponDictonary[1];
        foreach (KeyValuePair<int, Weapon> weapon in WeaponDictonary)
        {
            if (weapon.Value != equipedWeapon)
                weapon.Value.gameObject.SetActive(false);
        }

        //Events
        gameManager.stopFiring += StopFiring;
        gameManager.ResetCameraMovement += StopCameraMovement;
    }

    // Update is called once per frame
    void Update()
    {
        CurrState = (PlayerStates)CurrState.Process();
    }
    public IEnumerator StartDash()
    {
        isDashonCooldown = true;
        OnDasher();
        yield return new WaitForSeconds(dashCooldown);
        isDashonCooldown = false;
    }
    private void StopCameraMovement()
    {
        mouseLook.x = 0;
        mouseLook.y = 0;
    }
    public void SwapWeapon(int weaponId)
    {
        if (weaponDictonary.ContainsKey(weaponId) && weaponDictonary[weaponId].unlocked)
        {
            equipedWeapon.gameObject.SetActive(false);
            equipedWeapon = weaponDictonary[weaponId];
            equipedWeapon.gameObject.SetActive(true);

        }
    }
    public void loseAmmo()
    {
        if (OnAmmoLoss != null)
            OnAmmoLoss();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            if (armor.armor > 0)
            {
                armor.TakeDamage(damage);
            }
            else if (health.hp > 0)
            {
                health.TakeDamage(damage);
            }
            else if (health.hp <= 0)
            {
                //implement our Gameover/Die
            }
        }
    }

    public IEnumerator IFrameCoolDown()
    {
        isInvincible = true;
        yield return new WaitForSeconds(IFrameDuration);
        isInvincible = false;
    }

    private bool IsGameplayState()
    {
        return gameManager.CurrState == gameManager.GameplayState;
    }
    private void StopFiring()
    {
        CurrState.StopAllFire();
    }


    #region InputMethodEvents
    public void OnMove(InputAction.CallbackContext context)
    {
        xMovement = context.ReadValue<Vector2>().x;
        yMovement = context.ReadValue<Vector2>().y;
        //moveDirection = new Vector3(XMovement, 0, YMovement);
    }
    public void OnLookX(InputAction.CallbackContext context)
    {
        if (IsGameplayState())
            mouseLook.x = context.ReadValue<float>() * Time.deltaTime * MouseSensitivity;
    }

    public void OnLookY(InputAction.CallbackContext context)
    {
        if (IsGameplayState())
            mouseLook.y = context.ReadValue<float>() * Time.deltaTime * MouseSensitivity;
    }
    public void OnFirePrimary(InputAction.CallbackContext context)
    {
        if (IsGameplayState())
        {
            if (context.performed)
            {
                CurrState.PrimaryFire();
            }
            if (context.canceled)
            {
                CurrState.StopPrimaryFire();
            }
        }

    }

    public void OnFireAlternate(InputAction.CallbackContext context)
    {
        if (IsGameplayState())
        {
            if (context.performed)
            {
                CurrState.AltFire();
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && IsGameplayState())
        {
            CurrState.Dash();
        }

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CurrState.Jump();
        }
    }

    public void OnMelee(InputAction.CallbackContext context)
    {
        if (context.started && IsGameplayState())
        {
            CurrState.Melee();
        }
    }

    public void OnWeaponSelect(InputAction.CallbackContext context)
    {
        if (gameManager != null)
        {
            if (context.started)
            {
                gameManager.CurrState.OnWeaponSwap();
            }
            if (context.canceled)
            {
                if (gameManager.CurrState == gameManager.WeaponSwapState)
                    gameManager.CurrState.OnWeaponSwap();
            }
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            gameManager.CurrState.OnPause();
        }
    }

    public void OnThrowGrenade(InputAction.CallbackContext context)
    {

        if (context.started && IsGameplayState())
        {
            if (Grenade != null)
            {
                currState.Grenade();
            }
        }
    }


    #endregion InputMethodEvents


}
