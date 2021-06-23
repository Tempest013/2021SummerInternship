using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Swing : MonoBehaviour
{
    private List<Transform> waypointsTransform;
    public List<Vector3> waypoints;
    private Collider collider;
    private float cooldown = 1f;
    private bool onCd = false;

    private void Start()
    {
        waypointsTransform = GetComponentsInChildren<Transform>().ToList();
        waypointsTransform.RemoveAt(0);
        for (int i = 0; i < waypointsTransform.Count; i++)
            waypoints.Add(waypointsTransform[i].position);
        
        collider = GetComponent<Collider>();
    }

    private IEnumerator DisableCollider()
    {
        collider.enabled = false;
        onCd = true;
        yield return new WaitForSeconds(cooldown);
        collider.enabled = true;
        onCd = false;
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag=="Player"&&!onCd)
        {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            player.CurrState.SwitchToSwingState(this.gameObject.transform.position);
            StartCoroutine(DisableCollider());
           if(Vector3.Distance(other.transform.position,waypoints[0])
                >Vector3.Distance(other.transform.position,waypoints[waypoints.Count-1]))
            {
                waypoints.Reverse();
            }
            player.SwingState.path = waypoints;
        }
    }
}
