using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : PlayerStates
{
    public ClimbingState(PlayerCharacter player, Animator anim) : base(player, anim) { }

    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        //base.Enter();
    }

    // Update is called once per frame
    public override void Update()
    {
        CameraControls();
    }

    


}
