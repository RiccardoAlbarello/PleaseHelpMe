using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] MudEnigma mudEnigma;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mudEnigma.RemovePlatform(gameObject);
            gameObject.SetActive(false);
        }
    }
}

