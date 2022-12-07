using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#region notes

//Enemy types 
//-Fast Melee enemy: runs at you attacks simple is fast weak lots of em
//-Basic ranged enemy: Shoots a projectile at you simple (Medium range)
//-Suicide Bomber: Runs at you explodes (rework explosions to have knockback) loud fuckers like serious sam
//-Big melee enemy: has aoe attacks is fast lots of hp
//-Sniper: Long Range charges a beam at you then fires ( you can see the beam charge so shoot him then)
//-Disrupter: Ranged enemy whos goal is not to shoot at you but around you with slow projectiles this would 
//limit movement
//Machine gunner: fast projectiles medium range but very weak damage

//Enemy states
//Patrol state basic walking around state switches to active state if player is seen/ is in aggro range
//Active state/Agressive state for melee enemies chase the player navigate enviroment
//Ranged enemies get into range and vision of the player and fire
//Atack states: melee choose a random attack to preform play animation 
//ranged enemies randomly generate a number to decide what attack to perform do the attack put a cooldown 
//attack again when cooldown is done 

#endregion notes
public class Enemy : MonoBehaviour
{
    [Header("Stats")]

    protected Health hp;
    protected float moveSpeed;
    protected int damage;


    //Cashed Variables
    protected Animator anim;
    protected Rigidbody body;
    protected NavMeshAgent agent;
    protected Health health;
    protected CapsuleCollider collider;

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
    protected Material material;
    protected Color materialDefaultColor;
    protected Color currColor;
    [SerializeField] private GameObject skeleton;
   // public bool inRange = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
