using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public bool ballIsInHole = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            ballIsInHole = true;
        }
    }
}
