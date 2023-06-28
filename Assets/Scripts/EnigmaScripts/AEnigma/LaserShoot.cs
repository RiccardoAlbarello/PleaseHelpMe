using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    LaserScript laserScript;

    private void Start()
    {
        laserScript = GetComponentInParent<LaserScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rover"))
        {
            laserScript.ResetEnigma();
        }
    }
}
