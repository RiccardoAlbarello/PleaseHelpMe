using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPlatform : MonoBehaviour
{
    //[SerializeField] public Material emissiveMaterial;
    StreetController streetController;
    Material emissiveMaterial;
    Collider colliders;
    // Start is called before the first frame update
    void Start()
    {
        streetController = FindObjectOfType<StreetController>();
        emissiveMaterial = GetComponent<Renderer>().material;
        colliders = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rover") && gameObject == streetController.rightStreet[0])
        {
            emissiveMaterial.SetFloat("_Emissive", 1);
            //renderers.material.color = Color.yellow;
            streetController.RemovePlatform(gameObject);
            colliders.enabled = false;
        }
    }
}
