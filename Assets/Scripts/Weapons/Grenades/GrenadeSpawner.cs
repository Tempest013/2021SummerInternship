using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrenadeSpawner : MonoBehaviour
{
    #region singleton
    public static GrenadeSpawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        //else if (instance != this)
         //   Destroy(gameObject);
    }
    #endregion singleton

    [Header("Grenade Objects")]
    [SerializeField] private GameObject grenade;
    [SerializeField] private GameObject grenadeSpawner;
    [SerializeField] private GameObject grenadeHolder;

    [Header("Grenade Variables")]
  
    [SerializeField] private float forwardForce;
    [SerializeField] private float UpForce;
    [SerializeField] private float grenadeCD=2f;
    private bool grenadeIsOnCD;


    [Header("Grenade Types")]
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject freeze;
    [SerializeField] private GameObject flame;
    [SerializeField] private GameObject poison;

    [Header("Grenade Selection")]
    [SerializeField] private int grenadeIndex;

    [Header("Test Variables")]
    [SerializeField] private float gizmoSize;

    private SphereCollider defaultCollider;
    private GameObject newGrenade;
    protected Camera cam;
    private Vector3 forwardDirection;
    private Vector3 upDirection;
    //Event Stuff
    public static UnityEvent<Color> onChangeGrenade=new UnityEvent<Color>();
    public static UnityEvent<float> onThrowGrenade = new UnityEvent<float>();

  
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
                    onChangeGrenade?.Invoke(Color.black);
                    break;
                }
            case 1:
                {
                    grenade = freeze;
                    onChangeGrenade?.Invoke(Color.blue);
                    break;
                }
            case 2:
                {
                    grenade = flame;
                    onChangeGrenade?.Invoke(Color.red);
                    break;
                }
            case 3:
                {
                    grenade = poison;
                    onChangeGrenade?.Invoke(Color.green);
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
        if (!grenadeIsOnCD)
        {
            //newGrenade = Instantiate(grenade, grenadeSpawner.transform.position, Quaternion.identity);
            newGrenade = grenade;
            newGrenade.transform.position = grenadeHolder.transform.position;
            newGrenade.SetActive(true);
            newGrenade.transform.parent = null;
            forwardDirection = new Vector3(cam.transform.forward.x * forwardForce,cam.transform.forward.y* forwardForce, cam.transform.forward.z * forwardForce);
            upDirection = new Vector3(0,cam.transform.up.y * UpForce);
            Rigidbody body = newGrenade.GetComponent<Rigidbody>();
            body.velocity = Vector3.zero;
            body.AddForce(forwardDirection);
            body.AddForce(upDirection);
            grenadeIsOnCD = true;
            StartCoroutine(StartGrenadeCD());
            onThrowGrenade?.Invoke(grenadeCD);
        }

        // Invoke("Explosion", 5);        
    }
    IEnumerator StartGrenadeCD()
    {
        yield return new WaitForSeconds(grenadeCD);
        grenadeIsOnCD = false;
    }
    //IEnumerator GrowCollider(float delay, SphereCollider collider)
    //{
    //    yield return new WaitForSeconds(delay);
    //    collider.radius += blastRadius;
       
    //}

    private void Explosion()
    {
        Destroy(newGrenade);
    }

   
}
