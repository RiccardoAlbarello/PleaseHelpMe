using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{

    public bool isActive = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rover") || other.CompareTag("Interactable"))
            isActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rover") || other.CompareTag("Interactable"))
            isActive = false;
    }
}
