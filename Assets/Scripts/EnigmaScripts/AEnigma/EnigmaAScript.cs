using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaAScript : MonoBehaviour
{
    [SerializeField]
    PlateScript plate1;

    [SerializeField]
    PlateScript plate2;

    [SerializeField]
    GameObject monolith;

    // Update is called once per frame
    void Update()
    {
        if (plate1.isActive == true && plate2.isActive == true) 
        {
            monolith.SetActive(true);
        }
    }
}
