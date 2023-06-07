using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelScript[] wheels;

    [Header("Car Specs")]
    public float wheelBase;
    public float rearTrack;
    public float turnRadius;

    [Header("Inputs")]
    public float steerInput;

    private float ackermanAngleLeft;
    private float ackermanAngleRight;


    void Update()
    {

        steerInput = Input.GetAxis("Horizontal");

        if (steerInput > 0) // gira a destra
        {
            ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        }
        else if (steerInput < 0) // gira a sinistra
        {
            ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }
        else 
        {
            ackermanAngleLeft = 0;
            ackermanAngleRight = 0;
        }

        foreach (WheelScript w in wheels)
        {
            if (w.wheelFrontLeft)
                w.steerAngle = ackermanAngleLeft;

            if (w.wheelFrontRight)
                w.steerAngle = ackermanAngleRight;
        }
    }
}
