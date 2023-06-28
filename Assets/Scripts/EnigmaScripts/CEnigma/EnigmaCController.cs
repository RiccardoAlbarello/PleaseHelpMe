using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCController : MonoBehaviour
{ 
    [SerializeField]
    GameObject EnigmaC;

    [SerializeField]
    PedanaScript pedanaSu;

    [SerializeField]
    PedanaScript pedanaGiù;

    [SerializeField]
    PedanaScript pedanaDestra;

    [SerializeField]
    PedanaScript pedanaSinistra
        ;

    private float curveAmount = 5.0f;
    private float rotateSpeed = 3f;

    void Update()
    {
        //if (Input.GetKey(KeyCode.T)) 
        //{
        if (pedanaSu.isActive) 
        { 
           

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(0, 0.0f, curveAmount), rotateSpeed * Time.deltaTime);
        }

        //else if (Input.GetKey(KeyCode.G))
        //{
        else if (pedanaGiù.isActive)
        {

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(0, 0.0f, -curveAmount), rotateSpeed * Time.deltaTime);
        }

        //else if (Input.GetKey(KeyCode.F)) 
        //{
        else if (pedanaDestra.isActive)
        {

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(curveAmount, 0.0f, 0), rotateSpeed * Time.deltaTime);
        }

        else if (pedanaSinistra.isActive)
        {

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(-curveAmount, 0.0f, 0), rotateSpeed * Time.deltaTime);
        }
    }
}
