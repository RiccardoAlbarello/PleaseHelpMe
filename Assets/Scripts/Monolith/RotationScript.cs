using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [Header("Trail")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject destination;
    [SerializeField] float trailSpeed;

    [Header("Rotation Trigger")]
    [SerializeField] GameObject trigger;
    public float angleToRotate = 20f;
    public float speed = 5f;


    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            targetRotation *= Quaternion.AngleAxis(angleToRotate, Vector3.down);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

           
        }

        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Trigger");
            speed = 0;
            MonolithLight();
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Finish"))
    //    {
    //        Debug.Log("Trigger");
    //        speed = 0;
    //        MonolithLight();
    //    }
    //}

    void MonolithLight()
    {
        if (gameObject.activeSelf)
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
