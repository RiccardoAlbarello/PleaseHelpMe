using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivePlatform : MonoBehaviour
{
    public bool deathPlatform = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            deathPlatform = true;

        }
    }


}
