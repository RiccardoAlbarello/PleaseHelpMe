using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevaScript : MonoBehaviour
{

    public bool startEnigma = false;

    BoxCollider boxCollider;

    [SerializeField]
    Transform wayPoint1;

    [SerializeField]
    Transform wayPoint2;

    [SerializeField]
    float speed;

    Rigidbody rb;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    

    void Update()
    {
        if (startEnigma) 
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint1.position, speed);

            if (gameObject.transform.position == wayPoint1.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPoint2.position, speed);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Rover"))
        {
            Debug.Log(other.transform.name);
            startEnigma = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rover"))
        {
            Debug.Log(other.transform.name);
            startEnigma = false;
        }
    }


}
