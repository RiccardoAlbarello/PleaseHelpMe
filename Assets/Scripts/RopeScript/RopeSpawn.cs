using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1, 1000)]
    int lenght = 1;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    private bool canInteract = false;

    private GameObject InteractableObject;
    private CharacterJoint characterJointObject;


    private GameObject lastPartRope;
    private Rigidbody lastPartRopeRB;


    private bool ropeIsSpawned = false;


    void Update()
    {
        if (reset) 
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Rope")) 
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (Input.GetKeyDown(KeyCode.I) && canInteract == true) 
        {
            if (spawn == false)
            {
                spawn = true;
            }
            else if (spawn == true) 
            {
                spawn = false;
            }
        }

        if (spawn) 
        {
            Spawn();

            spawn = false;
        }
            
    }

    public void Spawn() 
    {
        int count = (int)(lenght / partDistance);

        for (int x = 0; x < count; x++)
        {
            GameObject tmp;

            tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1) , transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            tmp.name = parentObject.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());

                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }

            lastPartRope = tmp;
            
        }
        if (snapLast) 
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Interactable")) 
        {
            InteractableObject = other.gameObject;

            Debug.Log(InteractableObject.name);

            canInteract = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;

        InteractableObject = null;

    }
}

 
