using System.Collections;
using UnityEngine;

//Notes so im thinking the character spawns with a list of all the weapons already on him and when we pick up a weapon
//The unlock bool for that weapon is checked and thus we can access the weapon

public abstract class Weapon : MonoBehaviour
{

    //can be used to identify weapon or we just use type of might be better
    //we can sort the weapons by id number 
    public int id;
    public string name;

    //Ammo Counts
    public int maxAmmo;
    public int currAmmo;


    //aka firerate
    private float fireRate;
    protected bool canShoot;
    private bool isShooting;

    //To know what projectile to shoot
    protected ObjectPooling projectileType;

    //To get the instance of the player
    protected PlayerCharacter player;

    //To know the spawner
    [SerializeField] protected GameObject spawner;

    //Recoil values
    public float recoilRotateY;
    public float recoilRotateX;
    public Vector2 recoilSmoothing = new Vector2();
    public Vector2 currRecoil;
    public Vector2 maxRecoil;
    public float initialRotation;
    public bool recoilReset = true;

    //To know if we can use the weapon
    public bool unlocked;

    //For fullyautomatics
    protected IEnumerator shootingCoroutine;

    protected float FireRate { get => fireRate; set => fireRate = value; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }

    private void Start()
    {
        IsShooting = false;
        player = PlayerCharacter.instance;
        projectileType = ObjectPooling.instance;
    }
    private void Update()
    {
        if(currRecoil.x <= maxRecoil.x || -currRecoil.x >= -maxRecoil.x)
        {
            player.GetComponent<Transform>().Rotate(Vector3.up, recoilSmoothing.x);
            currRecoil.x += recoilSmoothing.x;
        }
        if(currRecoil.y <= maxRecoil.y)
        {
            player.RotationOnX -= recoilSmoothing.y;
            currRecoil.y += recoilSmoothing.y;
        }
        if(!isShooting && recoilReset)
        {
            player.RotationOnX = Mathf.Lerp(player.RotationOnX, initialRotation, 0.2f);
            currRecoil = new Vector2(0, 0);
            if (player.RotationOnX > initialRotation-0.1 && player.RotationOnX < initialRotation)
            recoilReset = false;
        }
        recoilSmoothing *= 0.9f;
    }

    public virtual void FirePrimary()
    {
        StartCoroutine(shootingCoroutine);
        if (canShoot == true)
        {
            StartCoroutine(ShotIsOnCD());
            IsShooting = true;
        }
    }

    protected virtual void Recoil(float recoilX, float recoilY)
    {
        recoilSmoothing.x = Random.Range(-recoilX, recoilX);
        recoilSmoothing.y = Random.Range(0, recoilY);
    }

    public abstract void FireSecondary();
    public virtual void StopPrimary()
    {
        StopCoroutine(shootingCoroutine);
        IsShooting = false;
        recoilReset = true;
        initialRotation = player.RotationOnX + currRecoil.y;
    }
    public abstract void StopSecondary();

    protected virtual IEnumerator ShotIsOnCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;
    }

    public Weapon()
    {
        //projectileType = ObjectPooling.instance;
    }
    protected virtual void OnDisable()
    {
        canShoot = true;
    }
}
