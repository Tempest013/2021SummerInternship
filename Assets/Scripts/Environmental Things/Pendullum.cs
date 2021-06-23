using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendullum : MonoBehaviour
{
   
    private HingeJoint joint;
    private JointLimits limits;
    private JointMotor motor;
    private JointSpring spring;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        motor = joint.motor;
        motor.force = 100;
        joint.useMotor = true;

        InvokeRepeating("NegativeTargetVelocity", 0f, 1.5f);
        InvokeRepeating("PositiveTargetVelocity", 0.5f, 3f);
       // NegativeTargetVelocity();


    }

    private void PositiveTargetVelocity()
    {
       // joint.useMotor = false;
        motor.targetVelocity = 100;
        motor.force = 180;
        joint.motor = motor;
        //joint.useMotor = true;
    }

    private void NegativeTargetVelocity()
    {
       // joint.useMotor = false;
        motor.targetVelocity = -75;
        motor.force = 100;
        joint.motor = motor;
      //  joint.useMotor = true;
    }
}
