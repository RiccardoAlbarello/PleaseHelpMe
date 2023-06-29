using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCController : MonoBehaviour
{ 
    [SerializeField]
    GameObject EnigmaC;

    [SerializeField]
    GameObject Monolith;

    [SerializeField]
    PedanaScript pedanaSu;

    [SerializeField]
    PedanaScript pedanaGiù;

    [SerializeField]
    PedanaScript pedanaDestra;

    [SerializeField]
    PedanaScript pedanaSinistra;

    [SerializeField]
    HoleScript holeScript;

    [SerializeField]
    StartEnigma startEnigma;

    [SerializeField]
    GameObject Porta;

    [SerializeField]
    Camera cameraEnigma;


    bool isEnigmaCompleted = false;

    private float curveAmount = 5.0f;
    private float rotateSpeed = 1f;

    void Update()
    {

        if (startEnigma.startEnigma) 
        {
            Porta.SetActive(true);

            pedanaDestra.gameObject.SetActive(true);

            cameraEnigma.gameObject.SetActive(true);
            
            Camera.main.gameObject.SetActive(false);
        }

        if (holeScript.ballIsInHole) 
        {
            isEnigmaCompleted = true;
            Porta.SetActive(false);
            pedanaDestra.gameObject.SetActive(false);
            cameraEnigma.gameObject.SetActive(true);
            Camera.main.gameObject.SetActive(true);
        }

        if (isEnigmaCompleted) 
        {
            Monolith.SetActive(true);
        }

        if (pedanaSu.isActive) 
        { 
           

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(0, 0.0f, curveAmount), rotateSpeed * Time.deltaTime);
        }
        else if (pedanaGiù.isActive)
        {

            EnigmaC.transform.rotation = Quaternion.RotateTowards(EnigmaC.transform.rotation, Quaternion.Euler(0, 0.0f, -curveAmount), rotateSpeed * Time.deltaTime);
        }
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
