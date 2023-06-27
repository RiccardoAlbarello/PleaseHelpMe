using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Leva") 
        {
            Debug.Log("Ciao ciao");
            other.gameObject.SetActive(false);
        }
    }
}
