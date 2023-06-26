using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    private float lastingLaser;

    [SerializeField]
    GameObject laser2;

    [SerializeField]
    GameObject rover;

    [SerializeField]
    GameObject cube;

    [SerializeField]
    GameObject leva;

    BoxCollider boxColliderLeva;

    [SerializeField]
    Transform startRoverPointPosition;

    [SerializeField]
    Transform startCubePointPosition;

    [SerializeField]
    Transform startLevaPointPosition;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(CastRaycast());
    }

    IEnumerator CastRaycast() 
    {
        while (true) 
        {
            SpawnLine();
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                if (hit.transform.name == "Rover") 
                {
                    ResetEnigma();
                    Debug.Log("RoverColpito");
                }

            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            yield return new WaitForSeconds(lastingLaser);
        }
    }

    public void ResetEnigma()
    {
        rover.transform.position = startRoverPointPosition.position;
        cube.transform.position = startCubePointPosition.position;
        leva.transform.position = startLevaPointPosition.position;
        leva.GetComponent<LevaScript>().startEnigma = false;
    }

    private void SpawnLine()
    {
        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, laser2.transform.position);
    }

    private void DespawnLine()
    {

        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
