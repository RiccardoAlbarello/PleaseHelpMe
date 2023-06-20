using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] MudEnigma mudEnigma;

    //[SerializeField] float timerBeforeSetActive;
    //[SerializeField] float timer;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mudEnigma.RemovePlatform(gameObject);
            gameObject.SetActive(false);
            //StartCoroutine(reactive());
        }
    }

    IEnumerator reactive()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(true);
        mudEnigma.AddPlatform(gameObject);
    }
}

