using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPlatform : MonoBehaviour
{
    StreetController streetController;
    Renderer renderers;
    // Start is called before the first frame update
    void Start()
    {
        streetController = FindObjectOfType<StreetController>();
        renderers = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gameObject == streetController.rightStreet[0])
        {
            renderers.material.color = Color.yellow;
            streetController.RemovePlatform(gameObject);
        }
    }
}
