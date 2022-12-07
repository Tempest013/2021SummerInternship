using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [Header("ID Values")]
    public int id;
    public string gunName;
    public bool unlocked;

    //Ammo Counts
    [Header("Ammo Counts")]
    public int maxAmmo;
    public int currAmmo;

    protected bool isShooting=false;



    //aka firerate

    [SerializeField] private float fireRate;
    [Header("FireRate")]
    protected bool canShoot;
  

    //cached Variables
    protected Transform playerTransform;

    //To know what projectile to shoot
    protected ObjectPooling projectileType;

    //To get the instance of the player
    protected PlayerCharacter player;

    //To know the spawner
    [SerializeField] protected GameObject spawner;

    //Recoil values
    [Header ("Recoil Values")]
    [SerializeField] protected float recoilX;
    [SerializeField] protected float minRecoilY;
    [SerializeField] protected float maxRecoilY;
    [SerializeField] protected float recoilDampening = 1;
    [SerializeField] private float recoilAdjustmentSpeed = .2f;
    protected Vector2 recoilSmoothing = new Vector2();
    protected Vector2 currRecoil;
    protected Vector2 maxRecoil;
    protected bool recoilReset = false;
    private float recoilCompensation=0f;
    protected float initialRotation;

    [Header("AudioClips")]
    [SerializeField] protected AudioClip[] audioClips;
    protected AudioSource audioSource;



    protected IEnumerator shotCD;
    


    protected float FireRate { get => fireRate; set => fireRate = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = PlayerCharacter.instance;
        playerTransform = player.GetComponent<Transform>();
        projectileType = ObjectPooling.instance;
        player.loseAmmo();
    }
    
    private void OnEnable()
    {
        if (PlayerCharacter.instance != null) 
        PlayerCharacter.instance.loseAmmo();
    }
    protected abstract void Update();

    public abstract void FirePrimary();

    protected void ApplyRecoil()
    {
        if (currRecoil.x <= maxRecoil.x || -currRecoil.x >= -maxRecoil.x)
        {
            playerTransform.Rotate(Vector3.up, recoilSmoothing.x);
            currRecoil.x += recoilSmoothing.x;
        }
        if (currRecoil.y <= maxRecoil.y)
        {
            player.RotationOnX -= recoilSmoothing.y;
            currRecoil.y += recoilSmoothing.y;
        }
    }
    protected void LoseAmmo()
    {
        currAmmo -= 1;
        player.loseAmmo();
    }
    protected void RecoilAdjust()
    {
        if (player.RotationOnX > initialRotation - recoilDampening && player.RotationOnX < initialRotation + recoilDampening
            || Mathf.Abs(recoilCompensation) > currRecoil.y || player.MouseLook.y > 0.5f)
        {

            currRecoil = new Vector2(0, 0);
            recoilCompensation = 0;
            recoilReset = false;
        }
        else
        {
            recoilCompensation += (player.RotationOnX - (Mathf.Lerp(player.RotationOnX, initialRotation, recoilAdjustmentSpeed)));
            player.RotationOnX = Mathf.Lerp(player.RotationOnX, initialRotation, recoilAdjustmentSpeed);
        }
    }
    protected virtual void Recoil()
    {
        recoilSmoothing.x = Random.Range(-recoilX, recoilX);
        recoilSmoothing.y = Random.Range(minRecoilY, maxRecoilY);
    }
  

    public bool CheckRecoilReset()
    {
        return (player.CurrState is DashState || player.CurrState is AirState || player.CurrState is GroundedState && recoilReset==false); 
    }

    public abstract void FireSecondary();
    public abstract void StopPrimary();
    
    public abstract void StopSecondary();
    protected virtual IEnumerator ShotIsOnCD()
    {
      
        canShoot = false;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;
    }

    public Weapon()
    {
        shotCD = ShotIsOnCD();
    }
    protected virtual void OnDisable()
    {
        canShoot = true;
    }
}
