using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithController : MonoBehaviour
{
    [SerializeField] GameObject particle;
    [SerializeField] GameObject destination;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonolithLight();
    }

    void MonolithLight()
    {
        if(gameObject.activeSelf)
        {
            particle.SetActive(true);
            StartCoroutine(LigthTransformPosition());
        }
    }

    IEnumerator LigthTransformPosition()
    {
        yield return new WaitForSeconds(3);
        particle.transform.position = Vector3.MoveTowards(particle.transform.position, destination.transform.position, speed * Time.deltaTime);
    }
}
