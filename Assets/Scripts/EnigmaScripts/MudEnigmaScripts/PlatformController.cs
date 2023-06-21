using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Header("Mud Platform")]
    [SerializeField] MudEnigma mudEnigma;

    [Header("Time Settings")]
    [SerializeField] float timeBeforeDeactivated;

    Renderer renderers;

    private void Update()
    {
        renderers = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mudEnigma.RemovePlatform(gameObject);
            renderers.material.color = Color.yellow;
            StartCoroutine(Deactive());
        }
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(timeBeforeDeactivated);
        renderers.material.color = Color.black;
        mudEnigma.AddPlatform(gameObject);
    }
}

