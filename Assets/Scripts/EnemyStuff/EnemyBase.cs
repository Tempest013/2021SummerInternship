using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    //States
    public EnemyState currState;
    private IdleState idleState;
    private AggresiveState aggresiveState;
    private AttackState attackState;
    private DeadState deadState;
    private JumpState jumpState;
    private BurnState burnState;
    private FrozenState frozenState;
    private PoisonState poisonState;

    //Cashed Variables
    public Animator anim;
    public Rigidbody body;
    public NavMeshAgent agent;
    public Health health;
    public CapsuleCollider collider;

    //Particle Effects 
    [SerializeField] private GameObject poisonParticleEffects;
    [SerializeField] private GameObject burningParticleEffects;
    [SerializeField] private GameObject spawnParticleEffects;

    //Enumerators DOTS
    public IEnumerator poisonDamage;
    public IEnumerator burnDamage;
    public IEnumerator freezeCoroutine;

    [Header("DOTS")]
    [SerializeField] private int burnTicks = 0;
    [SerializeField] private int poisonTicks = 0;
    [SerializeField] private int maxBurnTicks = 10;
    [SerializeField] private int maxPoisonTicks = 10;
    [SerializeField] private float burnTimings = .5f;
    [SerializeField] private float poisonTimings = 1f;
    [SerializeField] private float freezeTime = 3f;

    private bool isDead;

    private float redFlashTime = .05f;
    [Header("SFX")]
    [SerializeField] private AudioClip[] attackSFX;
    [SerializeField] private AudioClip[] deathSFX;
    private AudioSource audio;
    //coloring shit
  [SerializeField]  protected Material material;
    protected Color materialDefaultColor;
    protected Color currColor;
    
    public bool inRange = false;

    public IdleState IdleState { get => idleState; set => idleState = value; }
    public AggresiveState AggresiveState { get => aggresiveState; set => aggresiveState = value; }
    public AttackState AttackingState { get => attackState; set => attackState = value; }
    public DeadState DeadedState { get => deadState; set => deadState = value; }
    public JumpState JumpState { get => jumpState; set => jumpState = value; }
    public BurnState BurnState { get => burnState; set => burnState = value; }
    public FrozenState FrozenState { get => frozenState; set => frozenState = value; }
    public PoisonState PoisonState { get => poisonState; set => poisonState = value; }

    public bool IsDead { get => isDead; set => isDead = value; }
    public AudioClip[] AttackSFX { get => attackSFX; set => attackSFX = value; }
    public AudioClip[] DeathSFX { get => deathSFX; set => deathSFX = value; }
    public AudioSource Audio { get => audio; set => audio = value; }

    public void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        health = this.GetComponent<Health>();
    }

    public virtual void Start()
    {
        IdleState = new IdleState(this, anim);
        DeadedState = new DeadState(this, anim);
        JumpState = new JumpState(this, anim);
        BurnState = new BurnState(this, anim);
        FrozenState = new FrozenState(this, anim);
        PoisonState = new PoisonState(this, anim);
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        materialDefaultColor = material.color;
        currColor = materialDefaultColor;
        audio = GetComponent<AudioSource>();
        if (spawnParticleEffects != null)
            spawnParticleEffects.SetActive(true);
    }

    public void PlayAudio(AudioClip[] clips, float volume)
    {
        if (clips.Length > 0 && audio != null)
        {
            Audio.volume = volume;
            Audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }

    }
    public void Die()
    {
        currState.SwitchToDeadState();
    }

    public void Freeze()
    {
        if (freezeCoroutine != null)
            StopCoroutine(freezeCoroutine);
        freezeCoroutine = FreezeCoroutine();
        StartCoroutine(freezeCoroutine);
    }
    public void TurnOffParticleEffects()
    {
        burningParticleEffects.SetActive(false);
        poisonParticleEffects.SetActive(false);
        if (material != null)
            material.color = materialDefaultColor;
    }
    public void Poison(int damage)
    {
        poisonTicks = 0;
        if (poisonDamage != null)
            StopCoroutine(poisonDamage);
        poisonDamage = TakePoisonDOT(damage);
        StartCoroutine(poisonDamage);

    }
    public void Burn(int damage)
    {
        burnTicks = 0;
        if (burnDamage != null)
            StopCoroutine(burnDamage);
        burnDamage = TakeBurningDOT(damage);
        StartCoroutine(burnDamage);

    }
    private IEnumerator FreezeCoroutine()
    {
        currState.SwitchToFrozenState();
        material.color = Color.blue;
        currColor = Color.blue;
        yield return new WaitForSeconds(freezeTime);
        material.color = materialDefaultColor;
        currColor = materialDefaultColor;
        currState.SwitchToIdleState();
    }
    private IEnumerator TakeBurningDOT(int damage)
    {

        while (burnTicks < maxBurnTicks)
        {
            if (burningParticleEffects != null)
                burningParticleEffects.SetActive(true);
            yield return new WaitForSeconds(burnTimings);
            health.TakeDamage(damage);
            burnTicks++;
        }
        if (burningParticleEffects != null)
            burningParticleEffects.SetActive(false);
    }
    private IEnumerator TakePoisonDOT(int damage)
    {

        while (poisonTicks < maxPoisonTicks)
        {
            if (poisonParticleEffects != null)
                poisonParticleEffects.SetActive(true);
            yield return new WaitForSeconds(poisonTimings);
            health.TakeDamage(damage);
            poisonTicks++;
        }
        if (poisonParticleEffects != null)
            poisonParticleEffects.SetActive(false);
    }

    public IEnumerator FlashRed()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(redFlashTime);
        material.color = currColor;

    }
}
