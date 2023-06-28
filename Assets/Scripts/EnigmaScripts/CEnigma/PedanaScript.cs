using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedanaScript : MonoBehaviour
{
    public bool isActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Rover"))
            isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rover"))
            isActive = false;
    }
}
