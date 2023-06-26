using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "leva") 
        {
            Debug.Log("Ciao ciao");
            other.gameObject.SetActive(false);
        }
    }
}
