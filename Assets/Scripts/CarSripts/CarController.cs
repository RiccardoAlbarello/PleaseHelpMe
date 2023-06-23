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
    public float maxVelocity;

    [Header("Car Wheels")]
    public WheelScript wheelFrontLeft;
    public WheelScript wheelFrontRight;
    public WheelScript wheelRearLeft;
    public WheelScript wheelRearRight;
    private bool wheelsAreGrounded = false;

    [Header("Inputs")]
    public float steerInput;

    private float ackermanAngleLeft;
    private float ackermanAngleRight;

    [Header("FallDamage")]
    public float fallThresholdVelocity = 5f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundLayer;

    public bool grounded;
    private Rigidbody rb;
    public bool jumping = false;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }


        if (rb.velocity.magnitude > maxVelocity && grounded == true)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }


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


        bool previousGrounded = grounded;
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer, QueryTriggerInteraction.Ignore);


        if (!grounded)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if (grounded)
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        if ((!previousGrounded && grounded) && rb.velocity.y < -fallThresholdVelocity)
        {
            //TODO: Respawn;
            Debug.Log("Dead");
        }

        if ((wheelFrontLeft.grounded && wheelRearLeft.grounded) && (wheelFrontRight.grounded && wheelRearRight.grounded))
        {
            wheelsAreGrounded = true;
            
        }
        else
        {
            wheelsAreGrounded = false;
        }

        if (grounded == true && wheelsAreGrounded == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumping = true;
                //oldPosition = gameObject.transform.position;
                rb.velocity = (new Vector3(0, 1, 0)) * 200;
            }
        }

        if (grounded == false && wheelsAreGrounded == false && jumping == true)
        {
            transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * 2);
        }

        if (Time.time > nextActionTime)
        {

            nextActionTime += period;

            if (jumping == true) 
            {
                jumping = false;
            }
        }




    }



    //void OnDrawGizmosSelected()
    //{
    //    // Draw a yellow sphere at the transform's position
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(groundCheck.position, groundDistance);

    //}

    private void OnApplicationFocus(bool focus)
    {
        if (focus) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}

