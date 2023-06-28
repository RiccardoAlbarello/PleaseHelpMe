using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField]
    GameObject laserShoot;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    private float lastingLaser;

    [SerializeField]
    public GameObject laser2;

    [SerializeField]
    public GameObject rover;

    [SerializeField]
    public GameObject cube;

    [SerializeField]
    public GameObject leva;

    [SerializeField]
    public Transform startRoverPointPosition;

    [SerializeField]
    public Transform startCubePointPosition;

    [SerializeField]
    public Transform startLevaPointPosition;


    public bool line;

    public bool done;



    private void Start()
    {
       
        StartCoroutine(CastRaycast());
    }

    IEnumerator CastRaycast()
    {
        while (true)
        {
            line = false;
            yield return new WaitForSeconds(lastingLaser);
            done = false;

            line = true;
            yield return new WaitForSeconds(lastingLaser);
        }

    }

    private void Update()
    {
        if (line && done == false)
        {
            laserShoot.SetActive(!laserShoot.activeSelf);
            done = true;
        }
    }


   

    public void ResetEnigma()
    {
        rover.transform.position = startRoverPointPosition.position;
        cube.transform.position = startCubePointPosition.position;
        leva.transform.position = startLevaPointPosition.position;
        leva.GetComponent<LevaScript>().startEnigma = false;
    }

}
