using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    #region singleton
    public static GrenadeSpawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton

    [Header("Grenade Objects")]
    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject grenadeSpawner;

    [Header("Grenade Variables")]
    [SerializeField] private float fuseTimer;
    [SerializeField] protected float blastRadius;
    [SerializeField] private float forwardForce;
    [SerializeField] private float UpForce;

    [Header("Grenade Types")]
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject freeze;
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject poison;

    [Header("Grenade Selection")]
    [SerializeField] private bool normalGrenade;
    [SerializeField] private bool freezeGrenade;
    [SerializeField] private bool flameGrenade;
    [SerializeField] private bool poisonGrenade;
    [SerializeField] private int grenadeIndex;

    [Header("Test Variables")]
    [SerializeField] private float gizmoSize;

    private SphereCollider defaultCollider;
    private GameObject newGrenade;
    protected Camera cam;
    private Vector3 throwDirection;



    public bool NormalGrenade { get => normalGrenade; set => normalGrenade = value; }
    public bool FreezeGrenade { get => freezeGrenade; set => freezeGrenade = value; }
    public bool FlameGrenade { get => flameGrenade; set => flameGrenade = value; }
    public bool PoisonGrenade { get => poisonGrenade; set => poisonGrenade = value; }
    public float GizmoSize { get => gizmoSize; set => gizmoSize = value; }
    public int GrenadeIndex { get => grenadeIndex; set => grenadeIndex = value; }


    // Start is called before the first frame update
    void Start()
    {
         cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        throwDirection = new Vector3(cam.transform.forward.normalized.x * forwardForce, UpForce, cam.transform.forward.normalized.z * forwardForce);
        ChooseGrenade();
    }

    private void ChooseGrenade()
    {
        //just makes it easier to change the index as opposed to toggling off the old bool to toggle the new one
        switch (GrenadeIndex)
        {
            case 0:
                {
                    grenade = normal;
                    break;
                }
            case 1:
                {
                    grenade = freeze;
                    break;
                }
            case 2:
                {
                    grenade = flame;
                    break;
                }
            case 3:
                {
                    grenade = poison;
                    break;
                }
        }
        #region oldVersion
        //if(NormalGrenade == true)
        //{
        //    grenade = normal;
        //}
        //else if (FreezeGrenade == true)
        //{
        //    grenade = freeze;
        //}
        //else if (FlameGrenade == true)
        //{
        //    grenade = flame;
        //}
        //else if (PoisonGrenade == true)
        //{
        //    grenade = poison;
        //}
        #endregion oldVersion
    }

    public void ThrowGrenade()
    {
        newGrenade = Instantiate(grenade, grenadeSpawner.transform.position, Quaternion.identity);

        newGrenade.GetComponent<Rigidbody>().AddRelativeForce(throwDirection);

        defaultCollider = newGrenade.GetComponent<SphereCollider>();
        StartCoroutine(GrowCollider(fuseTimer, defaultCollider));

        // Invoke("Explosion", 5);        
    }

    IEnumerator GrowCollider(float delay, SphereCollider collider)
    {
        yield return new WaitForSeconds(delay);
        collider.radius += blastRadius;
       
    }

    private void Explosion()
    {
        Destroy(newGrenade);
    }

   
}
