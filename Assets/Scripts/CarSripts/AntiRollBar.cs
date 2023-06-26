using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRollBar : MonoBehaviour
{

	public WheelScript WheelL;
	public WheelScript WheelR;
	public float AntiRoll = 5000.0f;

	private Rigidbody car;

	void Start()
	{
		car = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;


        bool groundedL = WheelL.grounded;
        if (groundedL)
        {
            travelL = (-WheelL.transform.InverseTransformPoint(WheelL.groundedHit.point).y - WheelL.wheelRadius) / WheelL.springTravel;
        }

        bool groundedR = WheelR.grounded;
        if (groundedR)
        {
            travelR = (-WheelR.transform.InverseTransformPoint(WheelR.groundedHit.point).y - WheelR.wheelRadius) / WheelR.springTravel;
        }

        float antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
            car.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);

        if (groundedR)
            car.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
    }
}
