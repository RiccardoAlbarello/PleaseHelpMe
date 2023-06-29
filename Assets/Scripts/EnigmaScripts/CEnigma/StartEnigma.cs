using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnigma : MonoBehaviour
{
    public bool startEnigma = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rover")) 
        {
            startEnigma = true;
        }
    }
}
