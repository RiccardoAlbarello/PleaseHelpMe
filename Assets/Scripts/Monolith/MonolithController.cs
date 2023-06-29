using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithController : MonoBehaviour
{
    [Header("Trail")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject destination;
    [SerializeField] float trailSpeed;

    [Header("Rotation Angle")]
    [SerializeField] float rotation;
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
        if (Active)
            MonolithLight();
    }

    public bool Active = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Rover"))
        {
            targetRotation *= Quaternion.AngleAxis(angleToRotate, Vector3.left);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            if(targetRotation.eulerAngles.y <= rotation)
            {
                Active = true;
                speed = 0;
            }

        }

    }

    void MonolithLight()
    {
        particle.SetActive(true);
        StartCoroutine(LigthTransformPosition());
    }

    IEnumerator LigthTransformPosition()
    {
        yield return new WaitForSeconds(3);
        particle.transform.position = Vector3.MoveTowards(particle.transform.position, destination.transform.position, trailSpeed * Time.deltaTime);
    }
}
